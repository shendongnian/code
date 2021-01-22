    public Parent()
    {
        A.OnPropertyChanged += OnAPropertyChanged;
    }
    void OnAPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "X")
            if(PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs("A"))
    }
