    public void AddChild(MyClass theChild)
    {
        _children.Add(theChild);
        theChild.NotifyParentAdded(this);
    }
    
    public void AddParent(MyClass theParent)
    {
        _parent.Add(theParent);
        theParent.NotifyChildAdded(this);
    }
    public void NotifyChildAdded(MyClass theChild)
    {
        _children.Add(theChild);
    }
    
    public void NotifyParentAdded(MyClass theParent)
    {
        _parent.Add(theParent);
    }
