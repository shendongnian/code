    [assembly: ExportRenderer(typeof(MainPage), typeof(TabbedPageRenderer))]
    namespace YourNameSpace
    {
        public class TabbedPageRenderer : TabbedRenderer, TabLayout.IOnTabSelectedListener
        {
            //Overloaded Constructor required for Xamarin.Forms v2.5+
            public TabbedPageRenderer(Android.Content.Context context) : base(context)
            {
            }
            protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
            {
                base.OnElementChanged(e);
                Element.CurrentPageChanged += HandleCurrentPageChanged;
            }
    		void HandleCurrentPageChanged(object sender, EventArgs e)
    		{
    			var currentNavigationPage = Element.CurrentPage as NavigationPage;
    			if (!(currentNavigationPage.RootPage is PhrasesPage))
    				return;
    			var tabLayout = (TabLayout)ViewGroup.GetChildAt(1);
    			for (int i = 0; i < tabLayout.TabCount; i++)
    			{
    				var currentTab = tabLayout.GetTabAt(i);
    				var currentTabText = currentTab.Text;
    				if (currentTabText.Equals("Play") || currentTabText.Equals("Pause"))
    				{
    					Device.BeginInvokeOnMainThread(() => UpdateTab(currentTabText, currentTab, currentNavigationPage));
    					break;
    				}
    			}
    		}
            void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
            {
                System.Diagnostics.Debug.WriteLine("Tab Reselected");
    
                var mainPage = Application.Current.MainPage as MainPage;
    
                var currentNavigationPage = mainPage.CurrentPage as NavigationPage;
    
                if(currentNavigationPage.RootPage is PhrasesPage)
                Device.BeginInvokeOnMainThread(() => UpdateTab(currentNavigationPage.Title, tab, currentNavigationPage));
            }
    		void UpdateTab(string currentTabText, TabLayout.Tab tab, NavigationPage currentNavigationPage)
    		{
    			if (currentTabText.Equals("Puzzle"))
    			{
    				tab.SetIcon(IdFromTitle("Settings", ResourceManager.DrawableClass));
    				currentNavigationPage.Title = "Settings";
    			}
    			else
    			{
    				tab.SetIcon(IdFromTitle("Puzzle", ResourceManager.DrawableClass));
    				currentNavigationPage.Title = "Puzzle";
    			}
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
