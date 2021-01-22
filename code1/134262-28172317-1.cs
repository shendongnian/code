    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Microsoft.Win32;
    
    namespace WpfApplication94
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<ViewerApplication> viewers = new List<ViewerApplication>();
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    RegistryKey webClientsRootKey = hklm.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                    if (webClientsRootKey != null)
                        foreach (var subKeyName in webClientsRootKey.GetSubKeyNames())
                            if (webClientsRootKey.OpenSubKey(subKeyName) != null)
                                if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell") != null)
                                    if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open") != null)
                                        if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command") != null)
                                        {
                                            string commandLineUri = (string)webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue(null);
                                            if (string.IsNullOrEmpty(commandLineUri))
                                                continue;
                                            commandLineUri = commandLineUri.Trim("\"".ToCharArray());
                                            ViewerApplication viewer = new ViewerApplication();
                                            viewer.Executable = commandLineUri;
                                            viewer.Name = (string)webClientsRootKey.OpenSubKey(subKeyName).GetValue(null);
                                            viewers.Add(viewer);
                                        }
                }
                this.listView.ItemsSource = viewers;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Process.Start(((sender as Control).Tag as ViewerApplication).Executable, @"http://news.google.de");
            }
        }
    
        public class ViewerApplication
        {
            public string Name { get; set; }
            public string Executable { get; set; }
            public Icon Icon
            {
                get { return System.Drawing.Icon.ExtractAssociatedIcon(this.Executable); }
            }
            public ImageSource ImageSource
            {
                get
                {
                    ImageSource imageSource;
                    using (Bitmap bmp = Icon.ToBitmap())
                    {
                        var stream = new MemoryStream();
                        bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        imageSource = BitmapFrame.Create(stream);
                    }
                    return imageSource;
                }
            }
        }
    }
