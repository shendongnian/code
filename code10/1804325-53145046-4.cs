    public class MainActivity : AppCompatActivity
    {
        PlaybackBroadcastReceiver receiver;
        protected DrawerLayout drawerLayout;
        protected NavigationView navigationView;
        protected WakeLock WakeLock;
        private static MainActivity instance;
        public static MainActivity GetInstance()
        {
            return instance;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            receiver = new PlaybackBroadcastReceiver();
            instance = this;
        }
        protected override void OnStart()
        {
            base.OnStart();
            RegisterReceiver(receiver, new IntentFilter("renderEntry"));
        }
