    namespace AmRoNetworkMonitor.Demo
    {
        using System;
    
        internal class Program
        {
            private static void Main()
            {
                NetworkMonitor.StateChanged += NetworkMonitor_StateChanged;
                NetworkMonitor.StartMonitor();
    
                Console.WriteLine("Press any key to stop monitoring.");
                Console.ReadKey();
                NetworkMonitor.StopMonitor();
    
                Console.WriteLine("Press any key to close program.");
                Console.ReadKey();
            }
    
            private static void NetworkMonitor_StateChanged(object sender, StateChangeEventArgs e)
            {
                Console.WriteLine(e.IsAvailable ? "Is Available" : "Is Not Available");
            }
        }
    }
