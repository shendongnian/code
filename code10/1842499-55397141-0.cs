    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Remote;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Management;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    using System.Runtime.InteropServices;
    using System.Net;
    
    namespace ChromeAssistant
    {
        public partial class form_main_chromeassistant : Form
        {
            public form_main_chromeassistant()
            {
                InitializeComponent();
            }
    
            private void btn_test_profile_Click(object sender, EventArgs e)
            {
                CoreDriver CD = new CoreDriver();
    
                //Config
                CD.my_port = 50150;
                CD.my_name = "ChromeAssistant";
                CD.ConfigureProfile();
                CD.Initialize();
    
                CD.driver.Navigate().GoToUrl("https://www.google.ro/");
            }
        }
    
        #region CoreDriver
        public class CoreDriver
        {
            public IWebDriver driver;
            public string my_name { get; set; }
            public int my_port { get; set; }
    
            public string default_profile_dir = @"C:\Users\john\AppData\Local\Google\Chrome\";
            public string chromedriver_path = @"C:\Users\john\.nuget\packages\chromedriver_win32\";
            public string site_profile_path;
            public string site_profile_path_s;
            public string default_path;
    
            public void Initialize()
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--log-level=3");
                options.AddArgument("--test-type");
                options.AddArgument("--silent");
                options.AddArgument("user-data-dir=" + site_profile_path_s);
                options.AddArgument("--disable-plugins"); // disable flash
                
                var driverService = ChromeDriverService.CreateDefaultService(chromedriver_path);
                driverService.HideCommandPromptWindow = true;
                driverService.Port = my_port;
    
                driver = new ChromeDriver(driverService, options);
    
                //The 2 line were commented by me because I got 2 errors for them
                //driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 14));
                //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(15));
                //This was added by me to replace the 2 commented lines
                driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);
    
                IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;
                jscript.ExecuteScript("return window.stop");
            }
    
            public void ConfigureProfile()
            {
                site_profile_path_s = default_profile_dir + "profile " + my_name;
                site_profile_path = site_profile_path_s + @"\Default";
    
                default_path = default_profile_dir + @"User Data\Default";
    
                if (!Directory.Exists(site_profile_path))
                {
                    CreateBlankProfile();
                }
                else
                {
                    // copy existing chrome profile. Keep cache, extensions, etc.
                    CopyProfileFiles();
    
                    // but stay away from opened tabs
                    RemoveOpenedTabsFiles();
                }
    
            }
    
            public void CleanUpOldProfiles()
            {
                DirectoryInfo di = new DirectoryInfo(default_profile_dir);
                DirectoryInfo[] directories = di.GetDirectories("profile*", SearchOption.TopDirectoryOnly);
                if (directories.Count() > 0)
                {
                    foreach (var folder in directories)
                    {
                        try
                        {
                            Directory.Delete(folder.FullName, true);
                        }
                        catch
                        {
    
                        }
    
                    }
    
                }
            }
    
            public void CreateBlankProfile()
            {
                // new profile direftory
                CreateIfMissing();
    
                // copy existing chrome profile. Keep cache, extensions, etc.
                // but stay away from opened tabs
                CopyProfileFiles();
                CopyProfileFolders();
            }
    
            public void CopyProfileFiles()
            {
                // default profile location
                DirectoryInfo di = new DirectoryInfo(default_path);
    
                // copy files
                List<string> file_lib = new List<string>() { "Cookies", "Login", "Preferences", "Secur" };
                FileInfo[] files = di.GetFiles("*", SearchOption.TopDirectoryOnly);
                if (files.Count() > 0)
                {
                    foreach (var file in files)
                    {
                        if (PassFileOrFolder(file.Name, file_lib))
                        {
                            file.CopyTo(site_profile_path + @"\" + file.Name, true);
                        }
    
                    }
    
                }
            }
    
            public void RemoveOpenedTabsFiles()
            {
                // default profile location
                DirectoryInfo di = new DirectoryInfo(site_profile_path);
    
                // copy files
                List<string> file_lib = new List<string>() { "Current", "Last" };
                FileInfo[] files = di.GetFiles("*", SearchOption.TopDirectoryOnly);
                if (files.Count() > 0)
                {
                    foreach (var file in files)
                    {
                        if (PassFileOrFolder(file.Name, file_lib))
                        {
                            File.Delete(file.FullName);
                        }
    
                    }
    
                }
            }
    
            public void CopyProfileFolders()
            {
                // default profile location
                DirectoryInfo di = new DirectoryInfo(default_path);
    
                // copy folders
                List<string> folder_lib = new List<string>() { "databases", "Extension", " Storage", "Web Applications", "File System", "IndexedDB" };
                DirectoryInfo[] directories = di.GetDirectories("*", SearchOption.TopDirectoryOnly);
                if (directories.Count() > 0)
                {
                    foreach (var folder in directories)
                    {
                        if (PassFileOrFolder(folder.Name, folder_lib))
                        {
                            DirectoryCopy(folder.FullName, site_profile_path + @"\" + folder.Name, true);
                        }
    
                    }
    
                }
            }
    
            private void CreateIfMissing()
            {
                Directory.CreateDirectory(site_profile_path);
            }
    
            private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();
    
                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }
    
                // If the destination directory doesn't exist, create it. 
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }
    
                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                }
    
                // If copying subdirectories, copy them and their contents to new location. 
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
    
            public bool PassFileOrFolder(string input, List<string> library)
            {
                foreach (string name in library)
                {
                    if (input.Contains(name))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        #endregion
    }
