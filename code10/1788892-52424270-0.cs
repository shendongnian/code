    Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("MyNewSubKey");
            using (Microsoft.Win32.RegistryKey subsubkey = regKey.CreateSubKey("MyNewSubSubKey"))
            {
                subsubkey.SetValue("The cake", "U got the cake !");
                Console.WriteLine((String)(subsubkey.GetValue("The cake", "The cake is a lie"))); //Print U got the cake if success. Otherwise print "The cake is a lie"
            }
