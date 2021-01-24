       [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MediaPlayer chaos_player;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.activity_main);
            Button Chaos = FindViewById<Button>(Resource.Id.Chaos);
            Button StopChaos = FindViewById<Button>(Resource.Id.StopChaos);
            Button PauseChaos = FindViewById<Button>(Resource.Id.PauseChaos);
            //before click the button , you could instantiate MediaPlayer outside the click method;
            chaos_player = MediaPlayer.Create(this, Resource.Raw.Chaos);
            Chaos.Click += (e, o) =>
            {
                //if you click the button ,then call different method, do not instantiate MediaPlayer in here
                chaos_player.Start();
            };
            StopChaos.Click += (e, o) =>
            {
                chaos_player.Stop();
            };
            PauseChaos.Click += (e, o) =>
            {
                chaos_player.Pause();
            };
           
        }
        protected override void OnStop()
        {
            base.OnStop();
            //if you stop use MediaPlayer,please release it.
            chaos_player.Release();
        }
    }
