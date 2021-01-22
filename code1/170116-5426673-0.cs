        private string ReadSignature()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);
            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("Standard.htm");
                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();
                    
                    if (!string.IsNullOrEmpty(signature))
                    {
                        signature = signature.Replace("src=\"Standard_files/image001.jpg\"", "src=\"" + appDataDir + "/Standard_files/image001.jpg\"");
                    }
                }
            }
            return signature;
        }
