    public bool Equals( MyClass obj )
    {
    	if (obj == null) {
    		return false;
    	}
    	else {
    		return (this._data != null && this._data.Equals( obj._data ))
                             || obj._data == null;
    	}
    }
    public override bool Equals( object obj )
    {
    	if (obj == null || !(obj is MyClass)) {
    		return false;
    	}
    	else {
    		return this.Equals( (MyClass)obj );
    	}
    }
    
    public override int GetHashCode() {
    	return this._data == null ? 0 : this._data.GetHashCode();
    }
