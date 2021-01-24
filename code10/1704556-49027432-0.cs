    System.Management.ObjectQuery oq = new System.Management.ObjectQuery("SELECT * FROM Win32_Printer");
            ManagementObjectSearcher mos = new ManagementObjectSearcher(oq);
            ManagementObjectCollection moc = mos.Get();
            foreach (ManagementObject mo in moc)
            {
                string name = mo["Name"].ToString();
                var language = mo["LanguagesSupported"];
                Console.WriteLine(String.Format("Printer: {0} -- Language: {1}", name, language==null ? 0 : (language as ushort[])[0]));
            }
