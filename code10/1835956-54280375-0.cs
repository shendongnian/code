    namespace MyGreatNamespace.Droid
    {
        [Activity(Label = "MyGreatNamespace", 
            Icon = "@mipmap/icon",
            Theme = "@style/MainTheme", 
            MainLauncher = true, 
            SupportsPictureInPicture = true,
            ResizeableActivity =true,
            ConfigurationChanges = ConfigChanges.ScreenSize | 
                                ConfigChanges.SmallestScreenSize | 
                                ConfigChanges.ScreenLayout | 
                                ConfigChanges.Orientation)]
        public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                ....
            }
        }
    }
