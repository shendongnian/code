    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using Android.Support.V7.App;
    using Android.Views;
    using Android.Widget;
    
    namespace MySchool.Droid
    {
        [Activity(MainLauncher = true, Label = "MySchool", Icon = "@mipmap/icon")]
        public class SplashActivity : AppCompatActivity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                
                SetContentView(Resource.Layout.Splash);
                
                new Handler().PostDelayed(() =>
                {
                    StartActivity(new Intent(this, typeof(MainActivity)));
                    Finish();
                }, 2500);
            }
        }
    }
