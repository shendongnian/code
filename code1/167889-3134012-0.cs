    public string Name {
        get { return this.name; }
        set
        {
            this.name = value;
            this.PropertyChanged(typeof(Customer).GetMethod(behaviorMethod), value);
        }
    }
    private void PropertyChanged(MethodBase method, object value)
    {
        this.changeTrackingMethods.Add(method, value);
    }
