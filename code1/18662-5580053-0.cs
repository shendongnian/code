    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Security;
    using System.Diagnostics;
    static public bool Validate(string domain, string username, string password)
    {
        try
        {
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo()
            {
                FileName = "no_matter.xyz",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                LoadUserProfile = true,
                Domain = String.IsNullOrEmpty(domain) ? "" : domain,
                UserName = username,
                Password = Credentials.ToSecureString(password)
            };
            proc.Start();
            proc.WaitForExit();
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            switch (ex.NativeErrorCode)
            {
                case 1326: return false;
                case 2: return true;
                default: throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }   
