    public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
    {
        lock (this)
        {
            // Note: try/catch removed as it's pointless here, unless you're
            // *trying* to obscure the stack trace in case of an exception
            JobDeletionHelper helper = new JobDeletionHelper(properties);
            // Note that we're using a method group conversion here - we're not
            // invoking the method. We're creating a delegate which will invoke
            // the method when the delegate is invoked.
            SPSecurity.RunWithElevatedPrivileges(helper.DeleteJob);
        }
    }
    // We need this extra class because the properties parameter is *captured*
    // by the anonymous method
    class JobDeletionHelper
    {
        private SPFeatureReceiverProperties properties;
        internal JobDeletionHelper(SPFeatureReceiverProperties properties)
        {
            this.properties = properties;
        }
        public void DeleteJob()
        {
            // This is the code that was within the anonymous method
            SPWebApplication parentWebApp = (SPWebApplication)properties.Feature.Parent;
            DeleteExistingJob(JobName, parentWebApp);
        }
    }
