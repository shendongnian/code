    [assembly: ExportRenderer(typeof(MainPage), typeof(TabbedPageRenderer))]
    namespace YourNameSpace
    {
        public class TabbedPageRenderer : TabbedRenderer, TabLayout.IOnTabSelectedListener
        {
            //Overloaded Constructor required for Xamarin.Forms v2.5+
            public TabbedPageRenderer(Context context) : base(context)
            {
            }
            void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
            {
                System.Diagnostics.Debug.WriteLine("Tab Reselected");
    
                var mainPage = Application.Current.MainPage as MainPage;
    
                var currentNavigationPage = mainPage.CurrentPage as NavigationPage;
    
                if(currentNavigationPage.RootPage is PhrasesPage)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if(currentNavigationPage.Title.Equals("Play"))
                        {
                            currentNavigationPage.Title = "Pause";
                            currentNavigationPage.Icon = "ionicons_2_0_1_pause_outline_22.png";
                        }
                        else
                        {
                            currentNavigationPage.Title = "Play";
                            currentNavigationPage.Icon = "ionicons_2_0_1_play_outline_25.png";
                        }
                    });
                }
            }
        }
    }
