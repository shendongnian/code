    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.content);
        LoadAsyncData();
    }
    private async Task LoadAsyncData()
    {
        var tc1 = AsyncDataBase.SelectClass1();
        var tc2 = AsyncDataBase.SelectClass2();
        var c1 = await tc1;
        var c2 - await tc2;
        //Whatever was going in `ContinueWith`
    }
