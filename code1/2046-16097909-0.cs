    class Program
    {
        static void Main()
        {
            var applicationId = new Guid("b54f7b0d-87f9-4df9-9686-4d8fd76066dc");
            if (SingleInstanceManager.VerifySingleInstance(applicationId))
            {
                SingleInstanceManager.OtherInstanceStarted += OnOtherInstanceStarted;
                // start the application
            }
        }
        static void OnOtherInstanceStarted(object sender, StartupEventArgs e)
        {
            // Do something in response to another instance starting up.
        }
    }
