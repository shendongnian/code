    namespace WmiExample
    {
      using System;
      using System.Management;
      using System.Windows.Forms;
    
      public class WmiChangeEventTester
      {
        public WmiChangeEventTester()
        {
          try
          {
               // Your query goes below; "KeyPath" is the key in the registry that you
               // want to monitor for changes. Make sure you escape the \ character.
               WqlEventQuery query = new WqlEventQuery(
                    "SELECT * FROM RegistryKeyChangeEvent WHERE " +
                    "Hive = 'HKEY_LOCAL_MACHINE'" +
                    @"AND KeyPath = 'SOFTWARE\\Microsoft\\.NETFramework'");
    
               ManagementEventWatcher watcher = new ManagementEventWatcher(query);
               Console.WriteLine("Waiting for an event...");
               // Set up the delegate that will handle the change event.
               watcher.EventArrived += new EventArrivedEventHandler(HandleEvent);
    
               // Start listening for events.
               watcher.Start();
    
               // Do something while waiting for events. In your application,
               // this would just be continuing business as usual.
               System.Threading.Thread.Sleep(10000);
    
               // Stop listening for events.
               watcher.Stop();
          }
          catch(ManagementException managementException)
          {
               MessageBox.Show("An error occurred: " + err.Message);
          }
        }
            
        private void HandleEvent(object sender, EventArrivedEventArgs e)
        {
             // RegistryKeyChangeEvent occurs here; do something.
        }
    
        public static void Main()
        {
             // Just calls the class above to check for events...
             WmiChangeEventTester receiveEvent = new WmiChangeEventTester();
        }
      }
    }
