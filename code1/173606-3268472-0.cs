                System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo("path", "args");
            processStartInfo.Verb = "runas";
            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();
            }
