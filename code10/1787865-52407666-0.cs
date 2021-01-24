    private bool TryExecuteOpenSslCommand(string pathApp, string arguments, string content, out string response)
    {
        Process process = null;
        var status = false;
        try
        {
            var psi = new ProcessStartInfo(pathApp)
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(psi);
            psi.Arguments = arguments;
            process = Process.Start(psi);
            if (process == null)
                throw new Exception("Process is not started");
            var myWriter = process.StandardInput;
            var myOutput = process.StandardOutput;
            var myErrors = process.StandardError;
            myWriter.AutoFlush = true;
            myWriter.Write(content);
            myWriter.Close();
            var result = myOutput.ReadToEnd();
            var errors = myErrors.ReadToEnd();
            response = string.IsNullOrEmpty(result) ? errors : result;
            status = true;
        }
        catch (Exception ex)
        {
            response = ex.ToString();
        }
        finally
        {
            process?.Close();
        }
        return status;
    }
