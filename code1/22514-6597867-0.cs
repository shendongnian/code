        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress[] ips = NsLookup(computername, dnsserver);
            txtResult.Text = string.Empty;
            if (ips != null)
            {
                txtResult.Text = ips[0].ToString();
                txtResult.Text += Environment.NewLine;
                if (ips[1] != null)
                {
                    txtResult.Text += ips[1].ToString();
                }
                else
                {
                }
            }
            else
            {
                txtResult.Text = "No IP found";
            }
        }
            
        public IPAddress[] NsLookup(string computername, string domaincontroller)
        {
            IPAddress[] ips = new IPAddress[2];
            try
            {
                // Creating streamreaders to read the output and the errors
                StreamReader outputReader = null;
                StreamReader errorReader = null;
                string nslookup = @"C:\Windows\System32\Nslookup.exe";
                try
                {
                    // Setting process startupinfo
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(nslookup, computername + " " + domaincontroller);
                    processStartInfo.ErrorDialog = false;
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardError = true;
                    processStartInfo.RedirectStandardInput = true;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    // Starting Process
                    Process process = new Process();
                    process.StartInfo = processStartInfo;
                    bool processStarted = process.Start();
                    if (processStarted)
                    {
                        // Catching the output streams
                        outputReader = process.StandardOutput;
                        errorReader = process.StandardError;
                        string errorresult = errorReader.ReadLine();
                        errorReader.Close();
                        
                        if (errorresult != null)
                        {
                           // Failure got thrown in NsLookup Streamreading, try build-in Method
                           try
                           {
                                ips = Dns.GetHostAddresses(computername);
                                return ips;
                           }
                           catch
                           {
                                return null;
                           }
                    }
                    else
                    {
                        // Clearing out all the values before the addresses.
                        outputReader.ReadLine();
                        outputReader.ReadLine();
                        outputReader.ReadLine();
                        outputReader.ReadLine();
                        // Reading and Verifying the first outputline (the address is found after "Addresses:  ") - 2 part of the array is taken (after second space)
                        string outputline = outputReader.ReadLine();
                        string[] outputlineaftersplit = outputline.Split(' ');
                        string ipfortesting = outputlineaftersplit[2].Trim();
                        if (verifyIP(ipfortesting) != null)      // First entry is ipv4
                        {
                            ips[0] = verifyIP(ipfortesting);
                            outputline = outputReader.ReadLine();
                            ipfortesting = outputline.Trim();
                            if (verifyIP(ipfortesting) != null) // First and second entry are ipv4
                            {
                                ips[1] = verifyIP(ipfortesting);
                                return ips;
                            }
                            else
                            {
                                return ips;
                            }
                        }
                        else
                        {
                            outputline = outputReader.ReadLine();
                            ipfortesting = outputline.Trim();
                            if (verifyIP(ipfortesting) != null)
                            {
                                ips[0] = verifyIP(ipfortesting);
                                outputline = outputReader.ReadLine();
                                ipfortesting = outputline.Trim();
                                if (verifyIP(ipfortesting) != null)
                                {
                                    ips[0] = verifyIP(ipfortesting);
                                    outputline = outputReader.ReadLine();
                                    ipfortesting = outputline.Trim();
                                    if (verifyIP(ipfortesting) != null)
                                    {
                                        ips[1] = verifyIP(ipfortesting);
                                        return ips;
                                    }
                                    else
                                    {
                                        return ips;
                                    }
                                }
                                else
                                {
                                    return ips;
                                }
                            }
                            else
                            {
                                outputline = outputReader.ReadLine();
                                ipfortesting = outputline.Trim();
                                if (verifyIP(ipfortesting) != null)
                                {
                                    
                                    ips[0] = verifyIP(ipfortesting);
                                    outputline = outputReader.ReadToEnd();
                                    ipfortesting = outputline.Trim();
                                    if (verifyIP(ipfortesting) != null)
                                    {
                                        ips[1] = verifyIP(ipfortesting);
                                        return ips;
                                    }
                                    else
                                    {
                                        return ips;
                                    }
                                }
                                else
                                {
                                    ips = null;
                                    return ips;
                                }
                            }
                        }
                    }
                    }
                    else
                    {
                        // Failure got thrown in NsLookup Streamreading, try build-in Method
                        try
                        {
                            ips = Dns.GetHostAddresses(computername);
                            return ips;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("ERROR 1");
                    // Failure got thrown in NsLookup Streamreading, try build-in Method
                    try
                    {
                        ips = Dns.GetHostAddresses(computername);
                        return ips;
                    }
                    catch
                    {
                        return null;
                    }
                }
                finally
                {
                    if (outputReader != null)
                    {
                        outputReader.Close();
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("ERROR 2");
                // Failure got thrown in NsLookup Streamreading, try build-in Method
                try
                {
                    ips = Dns.GetHostAddresses(computername);
                    return ips;
                }
                catch
                {
                    return null;
                }
            }
        }
        public IPAddress verifyIP(string ipfromreader)
        {
            IPAddress ipresult = null;
            bool isIP = IPAddress.TryParse(ipfromreader, out ipresult);
            if (isIP && (ipresult.AddressFamily != AddressFamily.InterNetworkV6))
            {
                return ipresult;
            }
            else
            {
                return null;
            }
        }
    }
}
