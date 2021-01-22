    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    
    namespace MyNamespace
    {
        public class DotNetVersion
        {
            protected bool printVerification;
    
            public DotNetVersion(){
    			this.printVerification=false;
            }
            public DotNetVersion(bool printVerification){
    			this.printVerification=printVerification;
            }
    		
    
            public string getDotNetVersion(){
                string maxDotNetVersion = getVersionFromRegistry();
                if(String.Compare(maxDotNetVersion, "4.5") >= 0){
                    string v45Plus = get45PlusFromRegistry();
                    if(!string.IsNullOrWhiteSpace(v45Plus)) maxDotNetVersion = v45Plus;
                }
                log("*** Maximum .NET version number found is: " + maxDotNetVersion + "***");
    
                return maxDotNetVersion;
            }
    
            protected string get45PlusFromRegistry(){
                String dotNetVersion = "";
                const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
                using(RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey)){
                    if(ndpKey != null && ndpKey.GetValue("Release") != null){
                        dotNetVersion = checkFor45PlusVersion((int)ndpKey.GetValue("Release"));
                        log(".NET Framework Version: " + dotNetVersion);
                    }else{
                        log(".NET Framework Version 4.5 or later is not detected.");
                    }
                }
                return dotNetVersion;
            }
    
            // Checking the version using >= will enable forward compatibility.
            protected string checkFor45PlusVersion(int releaseKey){
                if(releaseKey >= 461308) return "4.7.1 or later";
                if(releaseKey >= 460798) return "4.7";
                if(releaseKey >= 394802) return "4.6.2";
                if(releaseKey >= 394254) return "4.6.1";
                if(releaseKey >= 393295) return "4.6";
                if((releaseKey >= 379893)) return "4.5.2";
                if((releaseKey >= 378675)) return "4.5.1";
                if((releaseKey >= 378389)) return "4.5";
    
                // This code should never execute. A non-null release key should mean
                // that 4.5 or later is installed.
                log("No 4.5 or later version detected");
                return "";
            }
    
            protected string getVersionFromRegistry(){
                String maxDotNetVersion = "";
                // Opens the registry key for the .NET Framework entry.
                using(RegistryKey ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "")
                                                .OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\")){
                    // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                    // or later, you can use:
                    // using(RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                    // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                    string[] subKeyNnames = ndpKey.GetSubKeyNames();
                    foreach(string versionKeyName in subKeyNnames){
                        if(versionKeyName.StartsWith("v")){
                            RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                            string name =(string)versionKey.GetValue("Version", "");
                            string sp = versionKey.GetValue("SP", "").ToString();
                            string install = versionKey.GetValue("Install", "").ToString();
                            if(string.IsNullOrWhiteSpace(install)){ //no install info, must be later.
                                log(versionKeyName + "  " + name);
                                if(String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                            }else{
                                if(!string.IsNullOrWhiteSpace(sp) && "1".Equals(install)){
                                    log(versionKeyName + "  " + name + "  SP" + sp);
                                    if(String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                }
    
                            }
                            if(!string.IsNullOrWhiteSpace(name)){
                                continue;
                            }
    
                            string[] subKeyNames = versionKey.GetSubKeyNames();
                            foreach(string subKeyName in subKeyNames){
                                RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                                name =(string)subKey.GetValue("Version", "");
                                if(!string.IsNullOrWhiteSpace(name)){
                                    sp = subKey.GetValue("SP", "").ToString();
                                }
                                install = subKey.GetValue("Install", "").ToString();
                                if(string.IsNullOrWhiteSpace(install)){
                                    //no install info, must be later.
                                    log(versionKeyName + "  " + name);
                                    if(String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                }else{
                                    if(!string.IsNullOrWhiteSpace(sp) && "1".Equals(install)){
                                        log("  " + subKeyName + "  " + name + "  SP" + sp);
                                        if(String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                    }
                                    else if("1".Equals(install)){
                                        log("  " + subKeyName + "  " + name);
                                        if(String.Compare(maxDotNetVersion, name) < 0) maxDotNetVersion = name;
                                    } // if
                                } // if
                            } // for
                        } // if
                    } // foreach
                } // using
                return maxDotNetVersion;
            }
    		
    		protected void log(string message){
    			if(printVerification) Console.WriteLine(message);
    		}
    
        } // class
    }
