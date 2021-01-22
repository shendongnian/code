    using System;
    using System.IO;
    using System.Collections.Generic;
    using MSOutlook = Microsoft.Office.Interop.Outlook;
    using System.Runtime.InteropServices;
    
    namespace Outlook2003KnowledgeBaseAddIn.Setup
    {
        public sealed class FolderHomePage
        {
            /// <summary>
            /// List of web view files that have been written out during this Outlook intance
            /// </summary>
            private static List<string> listWebViewFiles = new List<string>();
    
            /// <summary>
            /// Registers a specific managed type as a folder home page. Returns a file path for the folder home page
            /// </summary>
            /// <param name="viewType">Type of the home page control. 
            /// Control must be ComVisible should be registered safe for scripting</param>
            /// <returns>file path to the folder home page</returns>
            public static string RegisterType(Type viewType)
            {
                if (viewType == null)
                    return null;
    
                //TODO: ensure that viewType inherits from System.Windows.Forms.Control
    
                //Create the Local App Data directory for the Web view files to reside in
                string webViewDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Properties.Resources.WebViewDirectoryName);
                if (Directory.Exists(webViewDirectory) == false)
                    Directory.CreateDirectory(webViewDirectory);
    
                //Create the web view file name based on the viewType guid in the web view directory
                string webViewFile = Path.Combine(webViewDirectory, viewType.GUID.ToString("N") + ".htm");
    
                //if the file has been written out already in this session, return
                if (listWebViewFiles.Contains(webViewFile))
                    return webViewFile;
    
                //If the file exists, delete it (for versioning reasons)
                if (File.Exists(webViewFile))
                    File.Delete(webViewFile);
    
                //Open a file stream and text writer for the Web view stream
                FileStream stm = new FileStream(webViewFile, FileMode.Create, FileAccess.Write);
                TextWriter writer = new StreamWriter(stm, System.Text.Encoding.ASCII);
    
                //Look to see if the viewType has an init method that takes a single Outlook App parameter
                System.Reflection.MethodInfo initInfo = viewType.GetMethod("Initialize", new Type[] { typeof(MSOutlook.Application) });
    
                //If the viewType doesn't have an Init method, just write out the html page header
                //TODO move HTML code to resource strings
                if (initInfo == null)
                {
                    writer.WriteLine("<html><body rightmargin = '0' leftmargin ='0' topmargin ='0' bottommargin = '0'>");
                }
                //If the viewType does have an Init method, write script to trap the Body.OnLoad event and call the Init method
                //passing in the window.external.OutlookApplication object as the parameter
                else
                {
                    writer.WriteLine("<html><body rightmargin = '0' leftmargin ='0' topmargin ='0' bottommargin = '0' onload='OnBodyLoad()'>");
                    writer.WriteLine("<script>\n\tfunction OnBodyLoad()\n\t{\n\t\tvar oApp = window.external.OutlookApplication;");
                    writer.WriteLine("\t\t{0}.Initialize(oApp);", viewType.Name);
                    writer.WriteLine("\t}\n</script>");
                }
    
                //Write out an object tag that loads up the viewType as a com object via its class id
                writer.WriteLine("<object classid='clsid:{0}' ID='{1}' VIEWASTEXT width='100%' height='100%'/>", viewType.GUID, viewType.Name);
                writer.WriteLine("</body></html>");
    
                //Close the file
                writer.Close();
                stm.Close();
    
                //save this file name so we don't write it out multiple times per outlook session
                listWebViewFiles.Add(webViewFile);
    
                return webViewFile;
            }
    
            private const string CATID_SafeForScripting = "7DD95801-9882-11CF-9FA9-00AA006C42C4";
            private const string CATID_SafeForInitializing = "7DD95802-9882-11CF-9FA9-00AA006C42C4";
    
            /// <summary>
            /// Registers a managed type that's exposed for COM interop as safe for initializing and scripting
            /// </summary>
            /// <param name="comType"></param>
            public static void RegisterSafeForScripting(Type comType)
            {
                Guid clsid = comType.GUID;
                Guid interfaceSafeScripting = new Guid(CATID_SafeForScripting);
                Guid interfaceSafeForInitializing = new Guid(CATID_SafeForInitializing);
    
                ICatRegister reg = (ICatRegister)new ComComponentCategoriesManager();
                reg.RegisterClassImplCategories(ref clsid, 1, new Guid[] { interfaceSafeScripting });
                reg.RegisterClassImplCategories(ref clsid, 1, new Guid[] { interfaceSafeForInitializing });
            }
    
            /// <summary>
            /// Unregisters a managed type that's exposed for COM interop as safe for initializing and scripting
            /// </summary>
            /// <param name="comType"></param>
            public static void UnregisterSafeForScripting(Type comType)
            {
                Guid clsid = comType.GUID;
                Guid interfaceSafeScripting = new Guid(CATID_SafeForScripting);
                Guid interfaceSafeForInitializing = new Guid(CATID_SafeForInitializing);
    
                ICatRegister reg = (ICatRegister)new ComComponentCategoriesManager();
                reg.UnRegisterClassImplCategories(ref clsid, 1, new Guid[] { interfaceSafeScripting });
                reg.UnRegisterClassImplCategories(ref clsid, 1, new Guid[] { interfaceSafeForInitializing });
            }
    
        }
    
    
        [ComImport(), Guid("0002E005-0000-0000-C000-000000000046")]
        class ComComponentCategoriesManager
        {
        }
    
        [ComImport(), Guid("0002E012-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface ICatRegister
        {
            void RegisterCategories(int cCategories, IntPtr rgCategoryInfo);
    
            void UnRegisterCategories(int cCategories, IntPtr rgcatid);
    
            void RegisterClassImplCategories(
                    [In()] ref Guid rclsid,
                    int cCategories,
                    [In(), MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);
    
            void UnRegisterClassImplCategories(
                    [In()] ref Guid rclsid,
                    int cCategories,
                    [In(), MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);
    
            void RegisterClassReqCategories(
                [In()] ref Guid rclsid,
                int cCategories,
                [In(), MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);
    
            void UnRegisterClassReqCategories(
                [In()] ref Guid rclsid,
                int cCategories,
                [In(), MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);
        }
    
    }
