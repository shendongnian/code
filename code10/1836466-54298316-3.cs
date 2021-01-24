    private void DeviceChangedEvent(object sender, EventArrivedEventArgs e)
    {
        using (ManagementBaseObject MOBbase = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)
        {
            string oInterfaceType = MOBbase?.Properties["InterfaceType"]?.Value.ToString();
            string devicePNPId = MOBbase?.Properties["PNPDeviceID"]?.Value.ToString();
            string deviceDescription = MOBbase?.Properties["Caption"]?.Value.ToString();
            string EventMessage = $"{oInterfaceType}: {deviceDescription} ";
            switch (e.NewEvent.ClassPath.ClassName)
            {
                case "__InstanceDeletionEvent":
                    EventMessage += " removed";
                    this.BeginInvoke(new MethodInvoker(() => { this.UpdateUI(EventMessage); }));
                    break;
                case "__InstanceCreationEvent":
                    EventMessage += "inserted";
                    this.BeginInvoke(new MethodInvoker(() => { this.UpdateUI(EventMessage); }));
                    break;
                case "__InstanceModificationEvent":
                default:
                    Console.WriteLine(e.NewEvent.ClassPath.ClassName);
                    break;
            }
        }
    }
    private void UpdateUI(string message)
    {
       //Update the UI controls with the updated informations
    }
