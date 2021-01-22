    public event EventHandler MyPropertyChanged
    {
       add { AddDelegate(value); }
       remove { RemoveDelegate(value); }
    }
