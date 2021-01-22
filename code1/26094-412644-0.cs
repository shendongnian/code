    using System;
    using System.IO;
    
    class Info {
        public static void Main() {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives) {
                //There are more attributes you can use.
                //Check the MSDN link for a complete example.
                Console.WriteLine(d.Name);
                if (d.IsReady) Console.WriteLine(d.TotalSize);
            }
        }
    }
