        static void Main(string[] args)
        {
            string systemName = "172.30.11.148";      // Name of system beign pinged.  System name used instead of ip due to DHCP 
    
            Ping pingSender = new Ping();                       // Creates new ping object.  
            string data = "datadatadatadatadatadatadatadata";   // buffer of 32 bytes of data to transmit.
            byte[] buffer = Encoding.ASCII.GetBytes(data);      // buffer containing data.
            int pingTimeout = 120;          // Timeout in ms sent into pingSender.
            int maxWaitTimeout = 60;        // Maximum time to wait for system to reboot.
            int counter = 1;                // Used in while statement
            bool connectStatus = false;     // State of system connection.
            Console.WriteLine("Wait for reboot to start before trying to establish connection.");
            //Thread.Sleep(30000);            // Waits 30 seconds at start of reboot to allow network to close.
            Thread.Sleep(1000);
            try
            {
                // Performs a ping on the system.  If the system is available, while loop is exited and program
                // continues.  If the system is not available, program waits approximately 1 second and then
                // pings the system again.
                while (counter < maxWaitTimeout)
                {
                    // Pings the system with 32 byts of data and waits for timeout
                    Console.WriteLine("Connection attempt #: " + counter + " of " + maxWaitTimeout);
                    PingReply reply = pingSender.Send(systemName, pingTimeout, buffer);
                    Console.WriteLine("Status of ping to: {0} - {1}", systemName, reply.Status);
                    if (reply.Status.ToString() == "Success")
                    {
                        connectStatus = true;                     
                        Console.WriteLine("\nRoundTrip time: {0}", reply.RoundtripTime);
                        Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                        Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                        break;
                    }
                    
                    Thread.Sleep(880);
                    counter += 1;                  
                } // end while loop
                if (connectStatus == true)
                {
                    Console.WriteLine("\nAble to establish connection to: {0}", systemName);
                }
                else
                {
                    Console.WriteLine("\nUnable to establish network connection using ping to: {0}", systemName);
                }
            } // end try
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
       
            Console.ReadLine();     // Pause console
        } // end main   
