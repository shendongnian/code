    public static int RunProcessAsAdmin(string exeName, string parameters)
        {
            try {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = CurrentDirectory;
                startInfo.FileName = Path.Combine(CurrentDirectory, exeName);
                startInfo.Verb = "runas";
                //MLHIDE
                startInfo.Arguments = parameters;
                startInfo.ErrorDialog = true;
        
                Process process = System.Diagnostics.Process.Start(startInfo);
                process.WaitForExit();
                return process.ExitCode;
            } catch (Win32Exception ex) {
                WriteLog(ex);
                switch (ex.NativeErrorCode) {
                    case 1223:
                        return ex.NativeErrorCode;
                    default:
                        return ErrorReturnInteger;
                }
        
            } catch (Exception ex) {
                WriteLog(ex);
                return ErrorReturnInteger;
            }
        }
