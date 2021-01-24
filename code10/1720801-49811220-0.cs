    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions; 
    
    namespace selectmultipleaudio
    {
        [Activity(Label = "selectmultipleaudio", MainLauncher = true)]
        public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
                Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
    
                Button button = FindViewById<Button>(Resource.Id.button1);
                button.Click += Button_ClickAsync;
            }
    
            private async void Button_ClickAsync(object sender, System.EventArgs e)
            {
                var crossMedia = CrossMedia.Current;
                var media =  await crossMedia.PickVideoAsync();               
            }            
    
            public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
            {
                PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
