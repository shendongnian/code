    private string _X;
    public object X
    {
        get { return _X; }
        set
         {
            var a = ((ListBoxItem)value).Content as TextBlock;
            _X = a.Text;
           NotifyOfPropertyChange("X");
         }
    }
