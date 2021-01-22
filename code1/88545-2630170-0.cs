    public partial class Parent
    {
    
    	[Association(Name = "Parent_Child", Storage = "_Childs", ThisKey = "ParentKey", OtherKey = "ChildKey")]
    	public EntitySet<Child> Childs
    	{
    		get
    		{
    			return this._Childs;
    		}
    		set
    		{
    			this._Childs.Assign(value);
    		}
    	}
    }
