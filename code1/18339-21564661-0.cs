    using System;
    using System.ComponentModel.Composition;
    using System.Management;
    public class UsbDeviceMonitor
    {
        private ManagementEventWatcher plugInWatcher;
        private ManagementEventWatcher unPlugWatcher;
        private const string MyDeviceDescription = @"My Device Description";
        ~UsbDeviceMonitor()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (plugInWatcher != null)
                try
                {
                    plugInWatcher.Dispose();
                    plugInWatcher = null;
                }
                catch (Exception) { }
            if (unPlugWatcher == null) return;
            try
            {
                unPlugWatcher.Dispose();
                unPlugWatcher = null;
            }
            catch (Exception) { }
        }
        public void Start()
        {
            const string plugInSql = "SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity'";
            const string unpluggedSql = "SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity'";
            var scope = new ManagementScope("root\\CIMV2") {Options = {EnablePrivileges = true}};
            
            var pluggedInQuery = new WqlEventQuery(plugInSql);
            plugInWatcher = new ManagementEventWatcher(scope, pluggedInQuery);
            plugInWatcher.EventArrived += HandlePluggedInEvent;
            plugInWatcher.Start();
            var unPluggedQuery = new WqlEventQuery(unpluggedSql);
            unPlugWatcher = new ManagementEventWatcher(scope, unPluggedQuery);
            unPlugWatcher.EventArrived += HandleUnPluggedEvent;
            unPlugWatcher.Start();
        }
        private void HandleUnPluggedEvent(object sender, EventArrivedEventArgs e)
        {
            var description = GetDeviceDescription(e.NewEvent);
            if (description.Equals(MyDeviceDescription))
                // Take actions here when the device is unplugged
        }
        private void HandlePluggedInEvent(object sender, EventArrivedEventArgs e)
        {
            var description = GetDeviceDescription(e.NewEvent);
            if (description.Equals(MyDeviceDescription))
                // Take actions here when the device is plugged in
        }
        private static string GetDeviceDescription(ManagementBaseObject newEvent)
        {
            var targetInstanceData = newEvent.Properties["TargetInstance"];
            var targetInstanceObject = (ManagementBaseObject) targetInstanceData.Value;
            if (targetInstanceObject == null) return "";
            var description = targetInstanceObject.Properties["Description"].Value.ToString();
            return description;
        }
    }
