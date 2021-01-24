    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    [assembly: XamlCompilation(XamlCompilationOptions.Compile)]
    namespace MyNamespace
    {
        public partial class App : Application
        {
            private static bool AppIsActive = false;
    
            public App()
            {
                // InitializeComponent();
            }
    
            protected override void OnStart()
            {
                // Handle when your app starts
                AppIsActive = true;
            }
    
            protected override void OnSleep()
            {
                // Handle when your app sleeps
                AppIsActive = false;
            }
    
            protected override void OnResume()
            {
                // Handle when your app resumes
                AppIsActive = true;
            }
    
            public static bool IsAppActive()
            {
                return AppIsActive;
            }
        }
    }
