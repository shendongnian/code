    using Android.App;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Runtime;
    using Android.Widget;
    using Android.Content;
    
    namespace App80
    {
        [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
        public class MainActivity : AppCompatActivity
        {
            public EditText timer;
            Button btn;
            public int elapsedTime;    // counting values integer
            Handler myHandler;   // used to delay runnable for a second which delay_RATE
            int delay_RATE = 1000;    //delay
            Java.Lang.Runnable r;
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_main);
                elapsedTime = 60; // default value
                myHandler = new Handler();     //initializing handler
                r = new Java.Lang.Runnable(Run);
                timer = FindViewById<EditText>(Resource.Id.timertxt);
                btn = FindViewById<Button>(Resource.Id.btn1);
                btn.Click += Btn_Click;
                Counter();
            }
    
            protected override void OnResume()
            {
                base.OnResume();
                elapsedTime = 60;
                timer.Text = elapsedTime.ToString();
            }
    
            private void Btn_Click(object sender, System.EventArgs e)
            {
                var intent = new Intent(this, typeof(SeeTime));
                intent.PutExtra("Timer", elapsedTime);
                StartActivity(intent);
    
            }
            
            void Counter()
            {
                elapsedTime--;      // increment
                timer.Text = elapsedTime.ToString();
                myHandler.PostDelayed(r, delay_RATE);
                if (elapsedTime == 0)
                {
                    elapsedTime = 20;
                }
            }
            void Run()
            { Counter(); }
        }
    }
