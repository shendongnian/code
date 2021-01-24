    ProcessStartInfo psi = new ProcessStartInfo("sc");
            psi.Arguments = string.Format("{0} delete \"{1}\"", machineName, serviceName).Trim();
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            var process = Process.Start(psi);
            process.WaitForExit(timeoutMilliseconds);
            var output = process.StandardOutput.ReadToEnd();
            if (process.ExitCode != 0)
            {
                throw new Exception(string.Format("Service delete for Windows Service {0} failed.", serviceName));
            }
