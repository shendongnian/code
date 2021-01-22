    MyUserControl control = new MyUserControl();
    control += Control_PropertyChanged;
...
    void Control_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "MyProperty")
        {
          //Take appropriate action when MyProperty has changed.
        }
    }
