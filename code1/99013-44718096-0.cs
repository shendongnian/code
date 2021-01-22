    [ServiceContract]
    public interface IService
    {
    	[ServiceKnownType(typeof(MethodDeclaration))]
    	void ProcessMethodDeclaration(Declaration val);
    }
