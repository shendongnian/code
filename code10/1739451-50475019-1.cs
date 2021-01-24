    void Start()
    {
        delegatesystem.MyEvent += DelegateFunction;
    }
    void DelegateFunction(object sender, PopulateNamesEventArgs e)
    {
        e.AddName(gameObject.name);
    }
