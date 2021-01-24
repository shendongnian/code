public partial class ABCService : ServiceBase
{
    public static ABCService ServiceInstance;
    
    private void InitService()
    {
        ServiceInstance = this;
    }
}
	public static void StopService()
	{
	    if(ABCService.ServiceInstance != null)
		{
			ABCService.ServiceInstance.Stop();
		}
	}
	
