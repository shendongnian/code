     private void Application_Startup(object sender, StartupEventArgs e)
            {
                Process thisProc = Process.GetCurrentProcess();
                if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
                {
                    MessageBox.Show("Application running");
                    Application.Current.Shutdown();
                    return;
                }
     
                var wLogin = new LoginWindow();
     
                if (wLogin.ShowDialog() == true)
                {
                    var wMain = new Main();
                    wMain.WindowState = WindowState.Maximized;
                    wMain.Show();
                }
                else
                {
                    Application.Current.Shutdown();
                }      
            }
