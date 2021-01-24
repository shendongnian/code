    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ImageView iv_ImageView = FindViewById<ImageView>(Resource.Id.iv_ImageView);
            Bitmap icon=BitmapFactory.DecodeResource(Resources,Resource.Drawable.Capture);
            new shape(icon, iv_ImageView);
        }
    }
