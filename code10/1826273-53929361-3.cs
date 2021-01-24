    namespace ViewPager
    {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V4.View.ViewPager viewpager_page = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager_page);
            List<View> viewlist =new List<View>();
            //LayoutInflater.Inflate;
            viewlist.Add(LayoutInflater.Inflate(Resource.Layout.view_one,null,false));
            viewlist.Add(LayoutInflater.Inflate(Resource.Layout.view_Two, null, false));
            MyPagerAdapter mAdapter = new MyPagerAdapter(viewlist);
            viewpager_page.Adapter = mAdapter;
        }
    }
    }
