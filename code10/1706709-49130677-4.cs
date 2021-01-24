    using Android.OS;
    using Android.Support.V4.App;
    using Android.Views;
    
    namespace NavigationDrawerAndTabs.Fragments
    {
        public class Fragment2 : Android.Support.V4.App.Fragment
        {
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Create your fragment here
            }
    
            public static Fragment2 NewInstance()
            {
                var frag2 = new Fragment2 { Arguments = new Bundle() };
                return frag2;
            }
    
    
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                return inflater.Inflate(Resource.Layout.fragment2, container, false);
            }
        }
    }
