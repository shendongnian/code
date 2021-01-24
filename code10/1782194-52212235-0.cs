    Public String ContactName { 
    get 
    {
    return ContactName;
    } 
    set {
    ContactName = value; 
    RaisePropertyChange (() => ContactName);
    }
    }
