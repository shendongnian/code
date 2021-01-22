    public class AllTypesFacility : AbstractFacility {
    	protected override void Init() {
    		var asmList = FacilityConfig.Children["assemblies"].Children;
    		foreach (var asm in asmList)
    			Kernel.Register(AllTypes.Pick().FromAssemblyNamed(asm.Value));
    	}
    }
    
    
    var container = new WindsorContainer(@"..\..\AllTypesConfig.xml");
    container.AddFacility("alltypes", new AllTypesFacility());
    container.Resolve<NullLogger>();
