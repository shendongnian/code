    using Android.OS;
    using Android.Support.Design.Widget;
    using Android.Support.V4.App;
    using Android.Support.V4.View;
    using Android.Views;
    using Java.Lang;
    using System.Collections.Generic;
    
    namespace NavigationDrawerAndTabs.Fragments
    {
        public class Fragment1 : Fragment
        {
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                // Create your fragment here
            }
    
            public static Fragment1 NewInstance()
            {
                var frag1 = new Fragment1 { Arguments = new Bundle() };
                return frag1;
            }
    
    
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                View inflate = inflater.Inflate(Resource.Layout.fragment1, container, false);
    
                ViewPager viewPager = inflate.FindViewById<ViewPager>(Resource.Id.viewPager);
                MyFragmentPagerAdapter adapter = new MyFragmentPagerAdapter(ChildFragmentManager);
                viewPager.Adapter = adapter;
    
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
                    fgls.Add(Fragment2.NewInstance());
                    fgls.Add(Fragment3.NewInstance());
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
    
    
            }
        }
    
    
    }
