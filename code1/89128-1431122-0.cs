    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    
    namespace MyProcessSample
    {
        /// <summary>
        /// Shell for the sample.
        /// </summary>
        public class MyProcess
        {
           
            /// <summary>
            /// Opens the Internet Explorer application.
            /// </summary>
            public void OpenApplication(string myFavoritesPath)
            {
                // Start Internet Explorer. Defaults to the home page.
                Process.Start("IExplore.exe");
                        
                // Display the contents of the favorites folder in the browser.
                Process.Start(myFavoritesPath);
     
            }
            
            /// <summary>
            /// Opens urls and .html documents using Internet Explorer.
            /// </summary>
            public void OpenWithArguments()
            {
                // url's are not considered documents. They can only be opened
                // by passing them as arguments.
                Process.Start("IExplore.exe", "www.northwindtraders.com");
                
                // Start a Web page using a browser associated with .html and .asp files.
                Process.Start("IExplore.exe", "C:\\myPath\\myFile.htm");
                Process.Start("IExplore.exe", "C:\\myPath\\myFile.asp");
            }
            
            /// <summary>
            /// Uses the ProcessStartInfo class to start new processes, both in a minimized 
            /// mode.
            /// </summary>
            public void OpenWithStartInfo()
            {
                
                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                
                Process.Start(startInfo);
                
                startInfo.Arguments = "www.northwindtraders.com";
                
                Process.Start(startInfo);
                
            }
    
            public static void Main()
            {
                        // Get the path that stores favorite links.
                        string myFavoritesPath = 
                        Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
                    
                        MyProcess myProcess = new MyProcess();
             
                myProcess.OpenApplication(myFavoritesPath);
                myProcess.OpenWithArguments();
                myProcess.OpenWithStartInfo();
    
                   }    
        }
    }
