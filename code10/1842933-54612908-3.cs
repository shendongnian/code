    using EasyTabs;
    
    namespace WindowsFormsApp1
    {
        public partial class AppContainer : TitleBarTabs
        {
            public AppTabs()
            {
                InitializeComponent();
    
                AeroPeekEnabled = true;
                TabRenderer = new ChromeTabRenderer(this);
                Icon = mBible.Properties.Resources.appico;
            }
    
            public override TitleBarTab CreateTab()
            {
                return new TitleBarTab(this)
                {
                    Content = new Form1
                    {
                        Text = "New Tab"
                    }
                };
            }
        }
    }
