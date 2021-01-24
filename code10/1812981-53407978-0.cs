    lock (Clients)
                        {
                            if (Clients.Count > 0)
                            {
                                foreach (KeyValuePair<string, StateObject> c in Clients)
                                {
                                    if (c.Value.workSocket == handler)
                                    {
                                        Clients.Remove(c.Key);
                                        Console.WriteLine("Client automatically disconnected");
                                        Decode dr = new Decode();
                                        string m = dr.offlineMessage();
                                        SendMessage(ip, m);
                                        break;
                                    }
                                }
                            }
                        }
