    public MV_Main()
    {
        ...
        MyClass cl = new MyClass() { StringItem = "1", BoolItem = false };
        cl.PropertyChanged += Cl_PropertyChanged;
        SelectedStepRelaysForUI.Add(cl);
    }
    private void Cl_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Changed");
    }
