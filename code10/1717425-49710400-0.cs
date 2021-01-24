    [assembly: ExportRenderer(typeof(MainPage), typeof(TabbedPageRenderer))]
    namespace YourNameSpace
    {
        public class TabbedPageRenderer : TabbedRenderer, TabLayout.IOnTabSelectedListener
        {
            void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
            {
                System.Diagnostics.Debug.WriteLine("Tab Reselected");
    
                var mainPage = Application.Current.MainPage as MainPage;
    
                var currentNavigationPage = mainPage.CurrentPage as NavigationPage;
    
                if(currentNavigationPage.RootPage is PhrasesPage phrasesPage)
                {
                    Device.BeginInvokeOnMainThread(()=>
                    {
                        if(phrasesPage.Title.Equals("Play"))
                        {
                            phrasesPage.Title = "Pause";
                            phrasesPage.Icon = "ionicons_2_0_1_pause_outline_22.png";
                        }
                        else
                        {
                            phrasesPage.Title = "Play";
                            phrasesPage.Icon = "ionicons_2_0_1_play_outline_25.png";
                        }
                    });
                }
            }
        }
    }
