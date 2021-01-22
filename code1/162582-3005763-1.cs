    Calling parent
    ----------
    public MyForm f {get;set;}
    
    void DoStuff()
    {
    f = new MyForm();
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
