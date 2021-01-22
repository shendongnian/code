    public class MobileMonitoringSvcHost : ServiceHost
    {
        protected override void ApplyConfiguration()
        {
            // skip this line to not apply default config - unsure of other ramifications of doing this yet...
            base.ApplyConfiguration();
            base.Description.Endpoints.Clear();
        }
        public MobileMonitoringSvcHost(object singletonInstance, params Uri[] baseAddresses) : base(singletonInstance, baseAddresses)
        {
            
        }
    }
