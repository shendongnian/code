    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Xml.Linq;
    
    namespace Application2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private static string fullPath = "C:\\Files\\Users.xml";
            StringBuilder userList;
    
            public MainWindow()
            {
                InitializeComponent();
                userList = new StringBuilder();
    
                lblUsers.Content = string.Empty;
                lblUsers.Content = LoadUsers();
    
                CreateFileWatcher(@"C:\\Files");
            }
    
            private StringBuilder LoadUsers()
            {
                userList.AppendLine("  Users  ");
                userList.AppendLine("---------");
    
                if (File.Exists(fullPath))
                {
                    XElement xelement = XElement.Load(fullPath);
                    IEnumerable<XElement> users = xelement.Elements();
                    
                    foreach (var user in users)
                    {
                        userList.AppendLine(user.Attribute("Name").Value);
                    }              
                }
                else
                {
                    userList.AppendLine("Nothing to show ...");
                }
                return userList;
            }
    
            private void btnRefreshUsers_Click(object sender, RoutedEventArgs e)
            {
                userList.Clear();
                lblUsers.Content = string.Empty;
                lblUsers.Content = LoadUsers();
            }
    
            private void CreateFileWatcher(string path)
            {
                // Create a new FileSystemWatcher and set its properties.
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = path;
                /* Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "Users.xml";
    
                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                
                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
            
            // Define the event handlers.
            private  void OnChanged(object source, FileSystemEventArgs e)
            {
                // Specify what is done when a file is changed, created, or deleted.
                lblUsers.Dispatcher.Invoke(new Action(delegate ()
                {
                    userList.Clear();
                    lblUsers.Content = string.Empty;
                    lblUsers.Content = LoadUsers();
                }), System.Windows.Threading.DispatcherPriority.Normal);
            }      
        }
    }
