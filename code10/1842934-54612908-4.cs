    using System;
    using System.Windows.Forms;
    using EasyTabs;
    
    namespace WindowsFormsApp1
    {
        public partial class MainForm : Form
        {
            public static AppContainer tabbedApp = new AppContainer();
    
            public MainForm()
            {
                InitializeComponent();
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                tabbedApp.Tabs.Add(new TitleBarTab(tabbedApp)
                {
                    Content = new Form1
                    {
                        Text = "New Tab"
                    }
                });
                tabbedApp.SelectedTabIndex = 0;
    
                TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
                applicationContext.Start(tabbedApp);
    
                this.Hide();
            }
    
        }
    }
