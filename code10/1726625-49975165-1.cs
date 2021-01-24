        [Activity(Label = "Navigatetomainpage", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
        [IntentFilter(new[] { Intent.ActionSend }, Categories = new[] { Intent.CategoryDefault }, DataMimeType = "image/*", Label = "Navigatetomainpage")]
        [IntentFilter(new[] { Intent.ActionSend }, Categories = new[] { Intent.CategoryDefault }, DataMimeType = "text/plain", Label = "Navigatetomainpage")]
        [IntentFilter(new[] { Intent.ActionSendMultiple }, Categories = new[] { Intent.CategoryDefault }, DataMimeType = "image/*", Label = "Navigatetomainpage")]    
        public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        {
            protected override void OnCreate(Bundle bundle)
            {   
                Intent intent = Intent;
                String action = Intent.Action;
                String type = intent.Type;
    
                if (Intent.ActionSend.Equals(action) && type != null)
                {
                    if ("text/plain".Equals(type))
                    {
                        // Handle text being sent
                        // ...
                        // ...
                        // ...
                    }
                    else if (type.StartsWith("image/"))
                    {
                        // Handle single image being sent
                        // ...
                        // ...
                        // ...    
                    }
                }
                else if (Intent.ActionSendMultiple.Equals(action) && type != null)
                {
                    if (type.StartsWith("image/"))
                    {
                        // Handle multiple images being sent
                        // ...
                        // ...
                        // ...                        
                    }
                }
                else
                {
                    // Handle other intents, such as being started from the home screen                    
                }    
    
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
    
                base.OnCreate(bundle);
    
                global::Xamarin.Forms.Forms.Init(this, bundle);
                LoadApplication(new App());
            }
        }
