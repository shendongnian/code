    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    
    namespace App80
    {
        [Activity(Label = "SeeTime")]
        public class SeeTime : Activity
        {
            //MainActivity mainActivity;
            private EditText timer;
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.Time);
                timer = FindViewById<EditText>(Resource.Id.txtTime);
    
                int intValue = Intent.Extras.GetInt("Timer", 20);
    
                timer.Text = intValue.ToString();
    
            }
    
        }
    }
