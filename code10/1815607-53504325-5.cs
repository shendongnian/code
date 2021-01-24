            var pidlist = new List<int>() { 8, 2952, 630 };
            bool result = true;
            while (result)
            {
                Process[] processes = Process.GetProcesses();
                result = processes.Select(x => x.Id).Any(pid =>
                {
                    if (pidlist.Contains(pid)) return true;
                    return false;
                });
                System.Threading.Thread.Sleep(1000);
            }
