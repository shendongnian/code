    public class CRSyncServiceHost : ServiceHost
	{
		public CRSyncServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses) { }
		protected override void ApplyConfiguration()
		{
			base.ApplyConfiguration();
		}
	}
    public class CRSyncServiceFactory : ServiceHostFactory
	{
		protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			Uri newServiceAddress = new Uri("http://someaddress.com/CRSyncService.svc");
			CRSyncServiceHost newHost = new CRSyncServiceHost(serviceType, newServiceAddress);
			return newHost;
		}
	}
    <%@ ServiceHost Language="C#" Debug="true" Service="CRSyncService" Factory="CRSyncServiceFactory" CodeBehind="CRSyncService.svc.cs" %>
