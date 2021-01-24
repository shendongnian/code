	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(Resource.Layout.activity_main);           
        var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, dataSource);
        var listview = FindViewById<ListView>(Resource.Id.listView1);
        listview.Adapter = adapter;
        listview.ItemClick += delegate(object sender,AdapterView.ItemClickEventArgs e)
        {
            var item = adapter.GetItem(e.Position);
        };
	}
