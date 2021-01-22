    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Management;
    using System.ComponentModel;
    
    namespace ConsoleApplication4
    {
      public  class usbState
        {
           public usbState()
            {
     
            }
       private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
       {
           ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
           foreach (var property in instance.Properties)
           {
               Console.WriteLine(property.Name + " = " + property.Value);
           }
       }
       private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
       {
           ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
           foreach (var property in instance.Properties)
           {
               Console.WriteLine(property.Name + " = " + property.Value);
           }
       } 
        public  void bgwDriveDetector_DoWork(object sender, DoWorkEventArgs e)
        {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            insertWatcher.Start();
            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();
        }
    
    }
    class Class1
    {
           private static void Main(string[] args)
          {
              usbState  usb= new usbState();
              
              BackgroundWorker bgwDriveDetector = new BackgroundWorker();
              bgwDriveDetector.DoWork += usb.bgwDriveDetector_DoWork;
              bgwDriveDetector.RunWorkerAsync();
              bgwDriveDetector.WorkerReportsProgress = true;
              bgwDriveDetector.WorkerSupportsCancellation = true;
             // System.Threading.Thread.Sleep(100000);
               Console.ReadKey();
           }
       
    }
    }
