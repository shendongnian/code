    using System.Collections.Generic;
    
    namespace WpfApplication12
    {
    	public interface IEntity
    	{
    		int Id { get; set; }
    		string Name { get; set; }
    	}
    
    	public interface IHierachy<T>
    	{
    		IHierachy<T> Parent { get; }
    		List<IHierachy<T>> ChildItems { get; }
    		List<IHierachy<T>> LinkedItems { get; }
    	}
    
    	public class Entity<T> : IHierachy<T>, IEntity
    	{
    		private int _id;
    		public int Id
    		{
    			get { return _id; }
    			set { _id = value; }
    		}
    
    		private string _name;
    		public string Name
    		{
    			get { return _name; }
    			set { _name = value; }
    		}
    
    		public IHierachy<T> _parent;
    		public IHierachy<T> Parent
    		{
    			get
    			{
    				return _parent;
    			}
    		}
    
    		private List<IHierachy<T>> _childItems;
    		public List<IHierachy<T>> ChildItems
    		{
    			get
    			{
    				if( _childItems == null )
    				{
    					_childItems = new List<IHierachy<T>>();
    				}
    				return _childItems;
    			}
    		}
    
    		private List<IHierachy<T>> _linkedItems;
    		public List<IHierachy<T>> LinkedItems
    		{
    			get
    			{
    				if( _linkedItems == null )
    				{
    					_linkedItems = new List<IHierachy<T>>();
    				}
    				return _linkedItems;
    			}
    		}
    	}
    
    
    	public class Item : Entity<Item>
    	{
    	}
    
    	public class MetaItem : Entity<MetaItem>
    	{
    	}
    
    	public class Test
    	{
    		public void Test1()
    		{
    	        MetaItem meta1 = new MetaItem() { Id = 1, Name = "MetaItem1"};
    	        MetaItem meta2 = new MetaItem() { Id = 1, Name = "MetaItem 1.1"};
    	        Item meta3 = new Item() { Id = 101, Name = "Item 1" };
    
    			meta1.ChildItems.Add(meta3); // this line should not compile.
    			meta1.ChildItems.Add( meta2 );  // This is valid and gets compiled.
    		}
    	}
    
    }
