    public class Fragment1 : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View inflate = inflater.Inflate(Resource.Layout.layout1, container, false);
            ViewPager viewPager = inflate.FindViewById<ViewPager>(Resource.Id.viewpager);
            MyFragmentPagerAdapter adapter = new MyFragmentPagerAdapter(Activity.SupportFragmentManager);
            viewPager.Adapter=adapter;
    
            //TabLayout
            TabLayout tabLayout = inflate.FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(viewPager);
    
            return inflate;
        }
    
        public class MyFragmentPagerAdapter : FragmentPagerAdapter
        {
            public string[] titles = new string[] { "Tab1", "Tab2" };
            List<Fragment> fgls = new List<Fragment>();
            public MyFragmentPagerAdapter(Android.Support.V4.App.FragmentManager fm)
                : base(fm)
            {
                fgls.Add(new Fragment2());
                fgls.Add(new Fragment3());
    
            }
    
            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return fgls[position];
            }
    
            public override ICharSequence GetPageTitleFormatted(int position)
            {
    
                return new Java.Lang.String(titles[position]);
            }
    
            public override int Count
            {
                get { return titles.Length; }
            }
    
            public override int GetItemPosition(Java.Lang.Object objectValue)
            {
                return PositionNone;
            }
    
            public Android.Support.V4.App.Fragment GetFragment(int position)
            {
                return fgls[position];
            }
        }
    
    }
