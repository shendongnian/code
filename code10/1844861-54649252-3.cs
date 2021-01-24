    internal class dynamicType
    {
	    private string _name;
	    public string Name
	    {
		    get
		    {
			    return this._name;
		    }
		    set
		    {
			    if (this._name != value)
			    {
				     Console.WriteLine("changedto:" + value);
				     this._name = value;
			    }
		    }
	    }
    }
