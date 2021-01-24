            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            // set a quick TTL
            PingOptions options = new PingOptions(20, true);
            // internal support Task to handle Ping Exceptions like "host not found"
            async Task<KeyValuePair<string, bool>> PingHost(string host)
            {
                try
                {
                    var pingresult = await Task.Run(() => new Ping().SendPingAsync(host, sec * 1000, buffer, options));
                    //t.Wait();
                    if (pingresult.Status == IPStatus.Success)
                        return new KeyValuePair<string, bool>(host, true);
                    else
                        return new KeyValuePair<string, bool>(host, false);
                }
                catch
                {
                    return new KeyValuePair<string, bool>(host, false);
                }
            }
            //Using Tasks >>
            var watch = new Stopwatch();
            watch.Start();
            var tasksb = HostList.Select(HostName => PingHost(HostName.Key.ToString()));
            var pinglist = await Task.WhenAll(tasksb);
            foreach (var pingreply in pinglist)
            {
                HostList[pingreply.Key] = pingreply.Value;
            }
            watch.Stop();
            Log.Debug("PingList (Tasks) Time elapsed: " + watch.Elapsed);
            //Using Tasks <<
            
            return HostList;
        }
