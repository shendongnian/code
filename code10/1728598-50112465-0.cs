    public class MyNavigationItemSelectedListener : Java.Lang.Object, NavigationView.IOnNavigationItemSelectedListener
    {
        Context context;
        public MyNavigationItemSelectedListener(Context context)
        {
            this.context = context;
        }
        bool NavigationView.IOnNavigationItemSelectedListener.OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.nav_support)
            {
                Intent intent = new Intent(context, typeof(SupportActivity));  //the activity you want to open
                context.StartActivity(intent);
            }
            ///Other code
            ///...
            ///...
            ///...
        }
    }
