            string result = String.Empty;
            StreamReader srOutput = null;
            var oInfo = new ProcessStartInfo(exePath, parameters)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            var output = string.Empty;
            try
            {
                Process process = System.Diagnostics.Process.Start(oInfo);
                output = process.StandardError.ReadToEnd();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception)
            {
                output = string.Empty;
            }
            return output;
