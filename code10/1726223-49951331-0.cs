    [Activity(Label = "FirstDemo.Forms.Splash", Theme = "@style/MainTheme",  MainLauncher = true, NoHistory = true)]
    public class SplashScreen : MvxFormsSplashScreenAppCompatActivity<MvxFormsAndroidSetup<Core.App, App>, Core.App, App>
    {
    	public SplashScreen()
    		 : base(Resource.Layout.SplashScreen)
    	{
    	}
    
    	protected override void RunAppStart(Bundle bundle)
    	{
    		StartActivity(typeof(MainActivity));
    		base.RunAppStart(bundle);
    	}
    }
