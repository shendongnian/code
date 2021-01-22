    public static string MyPropertyPropertyName
    public string MyProperty {
        get { return _myProperty; }
        set {
            if (!String.Equals(value, _myProperty)) {
                _myProperty = value;
                NotifyPropertyChanged(MyPropertyPropertyName);
            }
        }
    }
    // in the consumer.
    private void MyPropertyChangedHandler(object sender,
                                          PropertyChangedEventArgs args) {
        switch (e.PropertyName) {
            case MyClass.MyPropertyPropertyName:
                // Handle property change.
                break;
        }
    }
