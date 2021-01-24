    namespace Project04
    {
        class Program
        {
            static bool _Terminate = false;
            static Timer aTimer = new Timer();
    
            static void Main(string[] args)
            {
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 5000;
                string choice;
                //menu
                do
                {
    
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("A) Start Ping");
                    Console.WriteLine("B) Stop Ping");
                    Console.WriteLine("C) Exit");
                    choice = Console.ReadLine().ToUpper();
    
                    switch (choice)
                    {
                        case "A":
                            _Terminate = false;
                            RunPing();
                            break;
    
                        case "B":
                            _Terminate = true;
                            break;
    
                        default:
                            break;
    
                    }
                    Console.Clear();
    
    
                } while (choice != "C");
    
            }
            public static void RunPing()
            {            
                aTimer.Enabled = true;
            }
    
            private static void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                string[] fields = null;
                //csv reader
                using (TextFieldParser parser = new TextFieldParser("Project04_URLs.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    fields = parser.ReadFields();
                }
                
                foreach (string URL in fields)
                {
                    if (_Terminate)
                    {
                        aTimer.Enabled = false;
                        return;
                    }
                    try
                    {
                        //ping
                        Ping myPing = new Ping();
                        PingReply reply = myPing.Send(URL, 5000);
                        if (reply != null)
                        {
                            //write ping to other csv
                            using (StreamWriter writer = new StreamWriter(string.Format("Ping_Data-{0}-{1}.csv", URL, DateTime.Now.ToString("ddMMyyyy-HHmmss"))))
                            {
                                writer.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                                // Redundant
                                writer.Flush();
                                writer.Close();
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("ERROR: You have Some TIMEOUT issue");
                    }
                }
            }
        }
    }
