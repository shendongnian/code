        namespace D6500.Views
        {
            [XamlCompilation(XamlCompilationOptions.Compile)]
            public partial class TaktTime : ContentView
    
            private void OnAppearing()
            {
                ....
                //Start timer after we have finished reading and writing to the display
                var NP = Application.Current.MainPage as NavigationPage;
                var mp = NP.RootPage as D6500.MainPage;
                mp.timerGSS.Start();
            }
        }
