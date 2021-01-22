          var info = Process.GetProcessesByName("devenv").FirstOrDefault();
            if (info != null)
            {
                Console.WriteLine(info.MainModule.FileVersionInfo.ProductName);
                Console.WriteLine(info.MainModule.FileVersionInfo.FileDescription);
            }
