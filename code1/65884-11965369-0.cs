     public static bool GetResolvedConnecionIPAddress(string serverNameOrURL, out IPAddress resolvedIPAddress)
            {
                bool isResolved = false;
                IPHostEntry hostEntry = null;
                IPAddress resolvIP = null;
                try
                {
                    if (!IPAddress.TryParse(serverNameOrURL, out resolvIP))
                    {
                        hostEntry = Dns.GetHostEntry(serverNameOrURL);
    
                        if (hostEntry != null && hostEntry.AddressList != null && hostEntry.AddressList.Length > 0)
                        {
                            if (hostEntry.AddressList.Length == 1)
                            {
                                resolvIP = hostEntry.AddressList[0];
                                isResolved = true;
                            }
                            else
                            {
                                foreach (IPAddress var in hostEntry.AddressList)
                                {
                                    if (var.AddressFamily == AddressFamily.InterNetwork)
                                    {
                                        resolvIP = var;
                                        isResolved = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        isResolved = true;
                    }
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    resolvedIPAddress = resolvIP;
                }
    
                return isResolved;
            }
