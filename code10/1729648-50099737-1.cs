    public class DashboardView : DrawerLayout
    {
        base.OnCreate(savedInstanceState);
        FrameLayout contentFrameLayout = FindViewById<FrameLayout>(Resource.Id.content_frame);
        LayoutInflater.Inflate(Resource.Layout.Main, contentFrameLayout); // here I Inflate the main.axml
    }
