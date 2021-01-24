            DateTime today = DateTime.Now.Date;
            var directoryInfo = new System.IO.DirectoryInfo(@"\\\\\Wna001\sv_prod_01\USERS\Results\thorn-prod\");
            int directoryCount = directoryInfo.GetDirectories().Where(x => x.CreationTime.Date == today || x.LastWriteTime == today).Count();
            string[] dirs = Directory.GetDirectories(@"\\\\\Wna001\sv_prod_01\USERS\Results\", "*PREBATCH*", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                int directoryCount1 = Directory.GetFiles("*.csv");
            }
