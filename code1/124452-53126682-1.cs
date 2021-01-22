    public static string ReadAllText(string path)
    {
        if (path.StartsWith("http"))
            return System.Text.Encoding.Default.GetString(ReadAllBytes(path));
        else
            return System.IO.File.ReadAllText(path);
    }
    public static byte[] ReadAllBytes(string path)
    {
        if (path.StartsWith("http"))
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "node.exe";                     // Node.js installs into the PATH
            psi.Arguments = "MyProxyDownladProgram.js " + 
                path.Replace("the base URL before the file name", "");
            psi.WorkingDirectory = "C:\\Folder\\With My\\Proxy Download Program";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            Process p = Process.Start(psi);
            byte[] output;
            try
            {
                byte[] buffer = new byte[65536];
                using (var ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            break;
                        ms.Write(buffer, 0, read);
                    }
                    output = ms.ToArray();
                }
                p.StandardOutput.Close();
                p.WaitForExit(60 * 60 * 1000);             // wait up to 60 minutes 
                if (p.ExitCode != 0)
                    throw new Exception("Exit code: " + p.ExitCode);
            }
            finally
            {
                p.Close();
                p.Dispose();
            }
            // convert the outputted base64-encoded string to binary data
            return System.Convert.FromBase64String(System.Text.Encoding.Default.GetString(output));
        }
        else
        {
            return System.IO.File.ReadAllBytes(path);
        }
    }
