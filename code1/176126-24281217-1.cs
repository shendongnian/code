      using System.Collections;
      using System.Diagnostics;
      using System.Management;
        if (File.Exists(@"D:\New folder\Test0001.wav"))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                FileInfo f = new FileInfo(@"D:\New folder\Test0001.wav");
                f.Delete();
            }
