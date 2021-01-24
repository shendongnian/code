            System.Diagnostics.Process p = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    FileName = "netsh.exe",
                    Arguments = $"interface ipv4 set interface \"{nicName}\" metric={metric}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            bool started = p.Start();
            if (started)
            {
                if (SpinWait.SpinUntil(() => p.HasExited, TimeSpan.FromSeconds(20)))
                {
                    Log.Write($"Successfully set {nicName}'s metric to {metric}");
                    Log.Write($"Sleeping 2 seconds to allow metric change on {nicName} to take effect.");
                    Thread.Sleep(2000);
                    return true;
                }
                Log.Write($"Failed to set {nicName}'s metric to {metric}");
                return false;
            }
