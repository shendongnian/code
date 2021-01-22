    Calling parent
    ----------
    public MyForm f {get;set;}
    
    void DoStuff()
    {
    MyForm f = new MyForm();
    f.Show();
    }
    
    MyForm
    ----------
    void DoOtherStuff()
    {
    this.hide();
    }
    
    Parent
    ----------
    void UnHideForm()
    {
    f.show();
    }
