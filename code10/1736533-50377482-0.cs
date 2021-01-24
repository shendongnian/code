    Child child = new Child();
	child.SetProperty(true);
    class Parent
    {
    	private bool _property;
    	
    	public virtual bool GetProperty() => _property;
    	public virtual void SetProperty(bool value) => _property = value;
    }
    
    class Child : Parent
    {
    	public override bool GetProperty() => base.GetProperty();
    }
