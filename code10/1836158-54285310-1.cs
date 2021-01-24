    protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);
                // Instantiate the layout
                overlayLayout =  FindViewById<LinearLayout>(Resource.Id.overlayLayout);
                progressBar =  FindViewById<ProgressBar>(Resource.Id.overlayProgressBar);
                description = FindViewById<TextView>(Resource.Id.textView1);
                description.Text = "Waiting for GPS";
                description.SetBackgroundColor(Color.Aqua);
                progressBar.SetBackgroundColor(Color.Red);
    
                switchBtn = FindViewById<Button>(Resource.Id.switchButton);
    
                switchBtn.Click += SwitchBtn_Click;
                overlayLayout.Visibility = Android.Views.ViewStates.Visible;
                isShown = true;
            }
    
            private void SwitchBtn_Click(object sender, System.EventArgs e)
            {
                if (isShown)
                {
                    overlayLayout.Visibility = Android.Views.ViewStates.Gone;
                    isShown = false;
                    switchBtn.Text = "Show";
                }
                else {
                    overlayLayout.Visibility = Android.Views.ViewStates.Visible;
                    isShown = true;
                    switchBtn.Text = "Hide";
                }
