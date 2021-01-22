    public void DoSomething()
    {
        BindingList<Foo> foos = getBindingList();
        foos.ListChanged += HandleFooChanged;
    }
    
    void HandleFooChanged(object sender, ListChangedEventArgs e)
    {
        MessageBox.Show(e.ListChangedType.ToString());
    }
