    if (int.Parse(value) > int.Parse(this._txtContents))
    {
        this._txtContents2 = "000";
    
        // notify WPF of our change to the property in a separate message
        Dispatcher.BeginInvoke((ThreadStart)delegate
        {
            NotifyPropertyChanged("txtContents2");
        });
    }
    else
    {
        this._txtContents2 = value;
        NotifyPropertyChanged("txtContents2");
    }
