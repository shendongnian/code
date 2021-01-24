    public static void GetAllNetworkAdapters()
        {           
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters.Where(a => a.OperationalStatus == OperationalStatus.Up))
            {                
                ActiveAdapters.Add(adapter.Id);
                string MAC = adapter.GetPhysicalAddress().ToString();
                ActiveAdapterMAC.Add(MAC);
                Logger.LogGenericText($"Adapter Properties => {adapter.Id} / {MAC}");
            }
        }
    public static string GetSubKeyValue()
        {
            RegistryKey Base = GetBaseKey();
            RegistryKey Key = Base.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}", true);
            string SelectedKey = null;
            string[] Values = Key.GetSubKeyNames();
            try
            {
                foreach (var key in Values)
                {
                    RegistryKey ValueChecker = Base.OpenSubKey(Constants.baseReg + key, true);
                    string NetCFID = ValueChecker.GetValue("NetCfgInstanceId").ToString();
                    if (NetCFID == ActiveAdapters[0])
                    {
                        SelectedKey = key;
                    }
                    ValueChecker.Close();
                }
            }
            catch(Exception ex)
            {
                if(ex is SecurityException)
                {
                    Key.Close();
                    return SelectedKey;
                }
            }
            
            Key.Close();
            return SelectedKey;
        }
    public static void ConfigMAC(bool Reset = false, bool RegisterDefault = false)
        {
            RegistryKey Base = GetBaseKey();
            string NICID = GetSubKeyValue();
            string NewMAC = GenerateMACAddress();
            CachedNICID = NICID;
            if (Config.WifiConnection)
            {
                NewMAC = GetRandomWifiMacAddress();
            }
            if (RegisterDefault)
            {               
                string CurrentMAC = GetMacIDWithCache();
                Constants.CurrentMACID = CurrentMAC;
                try
                {
                    RegistryKey RegisterKey = Base.OpenSubKey(Constants.baseReg + NICID, true);
                    if (RegisterKey.GetValue(Constants.DefaultMAC) != null)
                    {
                        RegisterKey.Close();
                        return;
                    }
                    else
                    {
                        RegisterKey.SetValue(Constants.DefaultMAC, CurrentMAC);
                        RegisterKey.Close();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogGenericText(ex.ToString());
                    return;
                }                      
            }
            if (Reset)
            {
                DeleteKey(NICID, true);
                return;
            }
            Logger.LogGenericText("Opening Sub Key => " + Constants.baseReg + NICID);
            RegistryKey Key = Base.OpenSubKey(Constants.baseReg + NICID, true);
            string[] KeyValues = Key.GetValueNames();
            
            if (!KeyValues.Contains(Constants.MacValue))
            {
                Key.SetValue(Constants.MacValue, NewMAC);
                Logger.LogGenericText("Value Set for " + Constants.MacValue + " as " + NewMAC);                
                Constants.CurrentMACID = NewMAC;
                Task.Run(() => ResetAdapter(NICID));
            }
            else
            {
                DeleteKey(NICID, false);
                Key.SetValue(Constants.MacValue, NewMAC);
                Logger.LogGenericText("Value Set for " + Constants.MacValue + " as " + NewMAC);
                Constants.CurrentMACID = NewMAC;
                Task.Run(() => ResetAdapter(NICID));
            }
            Key.Close();
        }    
        public static void DeleteKey(string Nicid, bool Restart)
        {
            Logger.LogGenericText("Deleting Previous Changed MAC...");
            RegistryKey Base = GetBaseKey();
            RegistryKey ResetKey = Base.OpenSubKey(Constants.baseReg + Nicid, true);
            ResetKey.DeleteValue(Constants.MacValue);
            ResetKey.Close();
            if (Restart)
            {
                Task.Run(() => ResetAdapter(Nicid));
                return;
            }
            else
            {
                return;
            }            
        }
        
        public static void ResetAdapter(string Nicid)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher
                                (new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE Index = " + Nicid));
            foreach (ManagementObject o in mos.Get().OfType<ManagementObject>())
            {
                Logger.LogGenericText("Disabling Adapter and Waiting for 6 Seconds.");
                o.InvokeMethod("Disable", null);
                Task.Delay(6000).Wait();
                o.InvokeMethod("Enable", null);
                Logger.LogGenericText("New MAC ID Set Sucessfully!");
            }
        }
