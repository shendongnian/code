    public partial class Form1 : Form
    {
    	public Form1()
    	{
            ...
    		
            ListView lv = new ListView();
    		lv.ListViewItemSorter = new MyCustomSorter(this);
    	}
    
    	private Dictionary<int, Picture> _pictures = new Dictionary<int,Picture>();
    
    	private class MyCustomSorter : IComparer
    	{
    		private Form1 _parent;
    
    		internal MyCustomSorter(Form1 form)
    		{
    			_parent = form;
    		}
    
    		#region IComparer Members
    
    		public int Compare(object x, object y)
    		{
    			ListViewItem item1 = x as ListViewItem;
    			ListViewItem item2 = y as ListViewItem;
    
    			if (x != null)
    			{
    				if (y != null)
    				{
    					Picture p1 = _parent._pictures[item1.Index];
    					Picture p2 = _parent._pictures[item2.Index];
    
    					return string.Compare(p1.Location, p2.Location);
    				}
    
    				// X is deemed "greater than" y
    				return 1;
    			}
    			else if (y != null)
    				return -1;		// x is "less than" y
    
    			return 0;
    		}
    
    		#endregion
    	}
    }
    
    public class Picture
    {
    	private string _location;
    
    	public string Location{
    		get { return _location; }
    	}
    }
