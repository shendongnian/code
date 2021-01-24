    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // some code
            CrossCurrentActivity.Current.Init(this, bundle);
            LoadApplication(new App());
        }
