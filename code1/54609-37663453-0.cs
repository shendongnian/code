    using System;
    using System.Management;
    
    namespace AppLaunchDetector
    {
        class Program
        {
            static void Main(string[] args)
            {           
                ManagementEventWatcher w = null;
                WqlEventQuery q;
                try
                {
                    q = new WqlEventQuery();
                    q.EventClassName = "Win32_ProcessStartTrace";
                    w = new ManagementEventWatcher(q);
                    w.EventArrived += new EventArrivedEventHandler(ProcessStartEventArrived);
                    w.Start();
                    Console.ReadLine(); // block main thread for test purposes
                }
                catch (Exception ex)
                {
    
                }
                finally
                {
                    w.Stop();
                }
            }
    
            static void ProcessStartEventArrived(object sender, EventArrivedEventArgs e)
            {
                foreach (PropertyData pd in e.NewEvent.Properties)
                {
                    Console.WriteLine("\n============================= =========");
                    Console.WriteLine("{0},{1},{2}", pd.Name, pd.Type, pd.Value);
                }
            }
        }
    }
