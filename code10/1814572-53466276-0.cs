	public class RebusInstaller : IWindsorInstaller
	{
	    public void Install(IWindsorContainer container, IConfigurationStore store)
	    {
	        Configure.With(new CastleWindsorContainerAdapter(container))
	            .(...)
	            .Start();
	    }
	}
