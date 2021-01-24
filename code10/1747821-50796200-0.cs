    namespace HelloXamarinFormsWorld.Android
    {
        [Activity(Label = "HelloXamarinFormsWorld", MainLauncher = true,
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
        public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // !!!!!! here !!!!!
                Rg.Plugins.Popup.Popup.Init(this, bundle);
            
                Xamarin.Forms.Forms.Init(this, bundle);
                LoadApplication (new App ());
            }
        }
    }
