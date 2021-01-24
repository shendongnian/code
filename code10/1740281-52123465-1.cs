         public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
                base.OnCreate(savedInstanceState);
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                LoadApplication(new App());
            }
            //needed for zxing scanner..
            public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
            {
                global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
        
