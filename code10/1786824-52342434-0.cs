    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using System.Threading.Tasks;
    
    [assembly: XamlCompilation(XamlCompilationOptions.Compile)]
    namespace LoadingSample
    {
        public partial class App : Application
        {
            public App()
            {
                InitializeComponent();
    
                //MainPage = new MainPage();
            }
    
            protected override async void OnStart()
            {
                // shows Loading...
                MainPage = new LoadPage();
    
                await Task.Yield();
                // Handle when your app starts
    
                // Just a simulation with 10 tries to get the data
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(500);
                    // await internet_service.InitializeAsync();
                    await MainPage.DisplayAlert(
                        "Connection Error", 
                        "Unable to connect with the server. Check your internet connection and try again", 
                        "Try again");            
                }
                await Task.Delay(2000);
                // after loading is complete show the real page
                MainPage = new MainPage();
            }
    
            protected override void OnSleep()
            {
                // Handle when your app sleeps
            }
    
            protected override void OnResume()
            {
                // Handle when your app resumes
            }
        }
    }
