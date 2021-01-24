    ServiceHost _host;  // <---------- new!
    private void KioskosServerForm_Load(object sender, EventArgs e)
    {
        Uri baseAddress = new Uri("http://10.131.131.14:8080/sendKioskMessage");
        try
        {
            // Create the ServiceHost.
            _host = new ServiceHost(typeof(KioskMessageService), baseAddress))
            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
           _host.Description.Behaviors.Add(smb);
            // Open the ServiceHost to start listening for messages. Since
            // no endpoints are explicitly configured, the runtime will create
            // one endpoint per base address for each service contract implemented
            // by the service.
            _host.Open();
         }
         catch (Exception exp)
         {
             MessageBox.Show(exp.InnerException.Message);
         }
     }
 
