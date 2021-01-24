        protected override void OnCreate(Bundle bundle)
        {
            var intent = Intent;
            if (intent.Extras != null)
            {
                var url = intent.Extras.Get("url");
                Intent browserIntent = new Intent(Intent.ActionView, Uri.Parse(url.ToString()));
                StartActivity(browserIntent);
            }
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
          
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            FirebasePushNotificationManager.ProcessIntent(this, Intent);
        }
