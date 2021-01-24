        namespace ExpandListViewDemo1
    {
        [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
        public class MainActivity : AppCompatActivity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);
                var listView = FindViewById<ExpandableListView>(Resource.Id.myExpandableListview);
                listView.SetAdapter(new ExpandableDataAdapter(this, Data.SampleData()));
            }
        }
    }
