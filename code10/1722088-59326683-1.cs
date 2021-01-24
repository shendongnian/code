            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            // set a quick TTL
            PingOptions options = new PingOptions(20, true);
            //Using Parallel >>
            watch = new Stopwatch();
            watch.Start();
            // avoid exception "Collection was modified; enumeration operation may not execute."
            // we need new dictionary and add values
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            Parallel.ForEach(HostList.Keys, (currHost) =>
            {
                try
                {
                    var pingReply = new Ping().Send(currHost, sec * 1000, buffer, options);
                    if (pingReply.Status == IPStatus.Success)
                        dictionary.Add(currHost, true);
                    else
                        dictionary.Add(currHost, false);
                }
                catch
                {
                    // handle Ping Exceptions like "host not found"
                    dictionary.Add(currHost, false);
                }
            });
            watch.Stop();
            Log.Debug("PingList (Parallel) Time elapsed: " + watch.Elapsed);
            //Using Parallel <<
            return dictionary;
        }
