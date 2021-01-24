    public class DrawerLayout : AppCompatActivity
    {
    TextView UserName;
    protected override void OnCreate(Bundle savedInstanceState)
    {
    	base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.drawerheaderlayout);
        UserName = FindViewById<TextView>(Resource.Id.callUsername) // here you call your username
        
    }
    
    }
