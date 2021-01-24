    <Application x:Class="SeveralDisplays.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:local="clr-namespace:SeveralDisplays"
                 Startup="OnStartup">
        <Application.Resources>
             
        </Application.Resources>
    </Application>
    using System.Drawing;
    using System.Windows;
    using System.Windows.Forms;
    using Application = System.Windows.Application;
    
    namespace SeveralDisplays
    {
        
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            private void OnStartup(object sender, StartupEventArgs e)
            {
                Window mainWindow1 = new MainWindow();
                Window mainWindow2 = new MainWindow2();
                Screen s1 = Screen.AllScreens[0];
                Screen s2 = Screen.AllScreens[1];
                Rectangle r1 = s1.WorkingArea;
                Rectangle r2 = s2.WorkingArea;
                mainWindow1.Top = r1.Top;
                mainWindow1.Left = r1.Left;
                mainWindow2.Top = r2.Top;
                mainWindow2.Left = r2.Left;
                mainWindow1.Show();
                mainWindow2.Show();
                mainWindow2.Owner = mainWindow1;
            }
        }
    } 
