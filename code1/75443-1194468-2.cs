    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using Microsoft.Win32;
    
    namespace [your namespace here]
    {
    	class IntegratedServiceInstaller
    	{
    		public void Install(String ServiceName, String DisplayName, String Description,
    			System.ServiceProcess.ServiceAccount Account, 
    			System.ServiceProcess.ServiceStartMode StartMode)
    		{
    			System.ServiceProcess.ServiceProcessInstaller ProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
    			ProcessInstaller.Account = Account;
    
    			System.ServiceProcess.ServiceInstaller SINST = new System.ServiceProcess.ServiceInstaller();
    
                System.Configuration.Install.InstallContext Context = new System.Configuration.Install.InstallContext();
    			string processPath = Process.GetCurrentProcess().MainModule.FileName;
    			if (processPath != null && processPath.Length > 0)
    			{
                    System.IO.FileInfo fi = new System.IO.FileInfo(processPath);
                    //Context = new System.Configuration.Install.InstallContext();
                    //Context.Parameters.Add("assemblyPath", fi.FullName);
                    //Context.Parameters.Add("startParameters", "Test");
    
                    String path = String.Format("/assemblypath={0}", fi.FullName);
                    String[] cmdline = { path };
                    Context = new System.Configuration.Install.InstallContext("", cmdline);
    			}
    
    			SINST.Context = Context;
                    SINST.DisplayName = DisplayName;
                    SINST.Description = Description;
                    SINST.ServiceName = ServiceName;
    			SINST.StartType = StartMode;
    			SINST.Parent = ProcessInstaller;
    
                // http://bytes.com/forum/thread527221.html
    //            SINST.ServicesDependedOn = new String[] {};
    
    			System.Collections.Specialized.ListDictionary state = new System.Collections.Specialized.ListDictionary();
    			SINST.Install(state);
    
                // http://www.dotnet247.com/247reference/msgs/43/219565.aspx
                using (RegistryKey oKey = Registry.LocalMachine.OpenSubKey(String.Format(@"SYSTEM\CurrentControlSet\Services\{0}", SINST.ServiceName), true))
                {
                    try
                    {
                        Object sValue = oKey.GetValue("ImagePath");
                        oKey.SetValue("ImagePath", sValue);
                    }
                    catch (Exception Ex)
                    {
    //                    System.Console.WriteLine(Ex.Message);
                    }
                }
    
    		}
    		public void Uninstall(String ServiceName)
    		{
    			System.ServiceProcess.ServiceInstaller SINST = new System.ServiceProcess.ServiceInstaller();
    
    			System.Configuration.Install.InstallContext Context = new System.Configuration.Install.InstallContext("c:\\install.log", null);
    			SINST.Context = Context;
                    SINST.ServiceName = ServiceName;
                SINST.Uninstall(null);
    		}
    	}
    }
