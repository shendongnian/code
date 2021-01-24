    [Activity(Label = "android", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        List<int> listImage = new List<int>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
            SetContentView(Resource.Layout.Main);
            InitData();
            HorizontalInfiniteCycleViewPager viewPager = FindViewById<HorizontalInfiniteCycleViewPager>(Resource.Id.hicvp);
            MyAdapter adapter = new MyAdapter(listImage, BaseContext);
            viewPager.Adapter = adapter;
        }
        private void InitData()
        {
            listImage.Add(Resource.Drawable.sample_1);
            listImage.Add(Resource.Drawable.sample_2);
            listImage.Add(Resource.Drawable.sample_3);
            listImage.Add(Resource.Drawable.sample_4);
            listImage.Add(Resource.Drawable.sample_5);
            listImage.Add(Resource.Drawable.sample_6);
            listImage.Add(Resource.Drawable.sample_7);
        }
    }
