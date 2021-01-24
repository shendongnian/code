     public Android.Support.V4.App.Fragment GetVisibleFragment(AppCompatActivity appCompatActivity)
        {
            Android.Support.V4.App.FragmentManager fragmentManager = appCompatActivity.SupportFragmentManager;
            IList<Android.Support.V4.App.Fragment> fragments = fragmentManager.Fragments;
            if (fragments != null)
            {
                foreach (Android.Support.V4.App.Fragment fragment in fragments)
                {
                    if (fragment != null && fragment.IsVisible)
                        return fragment;
                }
            }
            return null;
        }
