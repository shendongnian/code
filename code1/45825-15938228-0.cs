                string strKey = "Software\\Microsoft\\Internet Explorer\\PageSetup";
            bool bolWritable = true;
            RegistryKey oKey = Registry.CurrentUser.OpenSubKey(strKey, bolWritable);
            Console.Write(strKey);
            if (stringToPrint.Contains("Nalog%20za%20sluzbeno%20putovanje_files"))
            {
                oKey.SetValue("margin_bottom", 15);
                oKey.SetValue("margin_top", 0.19);
            }
            else
            {
                //Return onld walue
                oKey.SetValue("margin_bottom", 0.75);
                oKey.SetValue("margin_top", 0.75);
            }
