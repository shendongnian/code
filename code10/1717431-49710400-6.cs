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
                            tab.SetIcon(IdFromTitle("ionicons_2_0_1_pause_outline_22", ResourceManager.DrawableClass));
                        }
                        else
                        {
                            currentNavigationPage.Title = "Play";
                            tab.SetIcon(IdFromTitle("ionicons_2_0_1_play_outline_25", ResourceManager.DrawableClass));
                        }
                    });
                }
            }
    		void SetCurrentTabIcon(TabLayout.Tab tab, string icon)
            {
                tab.SetIcon(IdFromTitle(icon, ResourceManager.DrawableClass));
            }
            int IdFromTitle(string title, Type type)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(title);
                int id = GetId(type, name);
                return id;
            }
            int GetId(Type type, string memberName)
            {
                object value = type.GetFields().FirstOrDefault(p => p.Name == memberName)?.GetValue(type)
                    ?? type.GetProperties().FirstOrDefault(p => p.Name == memberName)?.GetValue(type);
                if (value is int)
                    return (int)value;
                return 0;
            }
        }
    }
