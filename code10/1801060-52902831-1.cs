        using System;
        using System.Windows;
    
        namespace WPFSystemTray
        {
        public partial class App : Application
        {
            public static bool IsExitApplication;
    
        public App()
        {
            Startup += App_Startup;
        }
    
        private void App_Startup(object sender, StartupEventArgs e)
        {
            WPFSystemTray.MainWindow.Instance.Show();
    
            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
            notifyIcon.Icon = WPFSystemTray.Properties.Resources.Dapino_Summer_Holiday_Palm_tree;
            notifyIcon.Visible = true;
     
            CreateContextMenu(notifyIcon);
        }
    
        private void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainWindow();
        }
    
        private void CreateContextMenu(System.Windows.Forms.NotifyIcon notifyIcon)
        {
            if (notifyIcon != null)
            {
                notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                notifyIcon.ContextMenuStrip.Items.Add("Application Name",
                    WPFSystemTray.Properties.Resources.palm_tree_icon).Click 
                    += NotifyIcon_ApplicationName_Click;
    
                notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += NotifyIcon_Exit_Click;
            }
        }
    
        private void NotifyIcon_ApplicationName_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
        }
    
        private void NotifyIcon_Exit_Click(object sender, EventArgs e)
        {
            IsExitApplication = true;
    
            MainWindow.Close();
    
            (sender as System.Windows.Forms.ToolStripItem).Owner.Dispose();
        }
    
        public void ShowMainWindow()
        {
            if (!MainWindow.IsVisible)
            {
                MainWindow.Show();
            }
            else
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
    
                MainWindow.Activate();
            }
        }
        }
        }
