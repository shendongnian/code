    public class LadderEntityBase : ICloneable
    	{
    		public Guid PK { get; set; }
    		public string Name { get; set; }
    		public string Comment { get; set; }
    		public LadderEntityBase(Guid guid)
    		{
    			this.PK = guid;
    			
    		}
    
    		public object Clone()
    		{
    			return this.MemberwiseClone();
    		}
    	}
    
    	public class Order : LadderEntityBase
    	{
    		public Order() : this(Guid.NewGuid())
    		{
    		}
    
    		public Order(Guid guid) : base(guid)
    		{
    			
    		}
    
    		public string OrderFrom { get; set; }
    	}
    
    	public class Parcel : LadderEntityBase
    	{
    		public Parcel() : this(Guid.NewGuid())
    		{
    		}
    
    		public Parcel(Guid guid) :base( guid)
    		{
    		
    		}
    
    		public string SentTo { get; set; }
    	}
