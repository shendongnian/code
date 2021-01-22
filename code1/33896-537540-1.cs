    class Foo
    {
    	public event EventHandler Changed = delegate { };
    
    	protected virtual void OnChanged()
    	{
    		this.Changed(this, EventArgs.Empty);
    	}
    }
    
    class Bar : Foo
    {
    	public Bar()
    	{
    		this.Changed += new EventHandler(this.Bar_Changed);
    	}
    
    	void Bar_Changed(Object sender, EventArgs e) { }
    }
    
    class Baz : Foo
    {
    	protected override void OnChanged() 
        { 
            base.OnChanged();
        }
    }
