            string ReadLine(int timeoutms)
            {
                ReadLineDelegate d = Console.ReadLine;
                IAsyncResult result = d.BeginInvoke(null, null);
                result.AsyncWaitHandle.WaitOne(timeoutms);//timeout e.g. 15000 for 15 secs
                if (result.IsCompleted)
                {
                    string resultstr = d.EndInvoke(result);
                    Console.WriteLine("Read: " + resultstr);
                    return resultstr;
                }
                else
                {
                    Console.WriteLine("Timed out!");
                    throw new TimedoutException("Timed Out!");
                }
            }
    
            delegate string ReadLineDelegate();
