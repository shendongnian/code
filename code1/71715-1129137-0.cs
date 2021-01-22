            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CustomPlaces.Clear();
            foreach (var item in System.IO.DriveInfo.GetDrives())
            {
                if (item.DriveType == DriveType.Removable)
                    ofd.CustomPlaces.Add(item.RootDirectory.ToString());
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(ofd.FileName);
                string s = f.Directory.Root.ToString();
                DriveInfo df = new DriveInfo(s);
                if (df.DriveType == DriveType.Removable)
                {
                    //DO STUFF WITH FILE
                }
            }
