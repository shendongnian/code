    private void DeviceChangedEvent(object sender, EventArrivedEventArgs e)
    {
        using (ManagementBaseObject moBase = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)
        {
            string oInterfaceType = moBase?.Properties["InterfaceType"]?.Value.ToString();
            string devicePNPId = moBase?.Properties["PNPDeviceID"]?.Value.ToString();
            string deviceDescription = moBase?.Properties["Caption"]?.Value.ToString();
            string eventMessage = $"{oInterfaceType}: {deviceDescription} ";
            switch (e.NewEvent.ClassPath.ClassName)
            {
                case "__InstanceDeletionEvent":
                    eventMessage += " removed";
                    this.BeginInvoke(new MethodInvoker(() => { this.UpdateUI(eventMessage); }));
                    break;
                case "__InstanceCreationEvent":
                    eventMessage += "inserted";
                    this.BeginInvoke(new MethodInvoker(() => { this.UpdateUI(eventMessage); }));
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
