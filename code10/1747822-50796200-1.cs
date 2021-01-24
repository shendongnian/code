    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
          // !!!!!! here !!!!!
          Rg.Plugins.Popup.Popup.Init();
          
          global::Xamarin.Forms.Forms.Init ();
          LoadApplication (new App ());
          return base.FinishedLaunching (app, options);
        }
    }
