    static bool EncryptPGP(string inFile, string outFile)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GNU\GnuPG"); //LocalMachine
                if (key != null)
                {
                    string path = key.GetValue("Install Directory").ToString();
                    string pgpPath = string.Format("{0}\\gpg.exe", path);//@"C:\tools\GNU\GnuPG\gpg.exe";
                    string password = "No no no no no";
                    string keyName = "hihi";
                    string args = string.Format(@"--batch --yes --passphrase {0} --recipient {1} --encrypt --output ""{2}"" --sign ""{3}""", password, keyName, outFile, inFile);
                    Process proc = Process.Start(pgpPath, args);
                    if (!proc.HasExited)
                    {
                        proc.WaitForExit();
                    }
                    return proc.ExitCode == 0;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return false;
        }
