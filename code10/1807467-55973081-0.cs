    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        {
            public static Intent testServiceIntent;
    
            protected override void OnCreate(Bundle savedInstanceState)
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
    
                base.OnCreate(savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
    
                testServiceIntent = new Intent(this.BaseContext, typeof(TestService));
    
                LoadApplication(new App());
            }
        }
