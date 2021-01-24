        try
        {
            IPHostEntry host = default(IPHostEntry);
            while (host == null)
            {
                try
                {
                    host = Dns.GetHostEntry("localhost");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", 
                     e.ToString());
                }
            }  // end while
        }
        catch (Exception e)
        {
                    Console.WriteLine("Unexpected exception : {0}", 
                     e.ToString());
         }
