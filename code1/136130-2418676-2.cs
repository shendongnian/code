    [ServiceContract(Namespace="Tracking/BusinessFunction")]
    public partial interface IBusinessFunctionDAO {
    
        [OperationContract]
        BusinessFunction GetBusinessFunction(Int32 businessFunctionRefID);
    
        [OperationContract]
        IEnumerable<Project> GetProjects(Int32 businessFunctionRefID);
    }
    
    [ServiceContract(Namespace="Tracking/BusinessUnit")]
    public partial interface IBusinessUnitDAO {
    
        [OperationContract]
        BusinessUnit GetBusinessUnit(Int32 businessUnitRefID);
    
        [OperationContract]
        IEnumerable<Project> GetProjects(Int32 businessUnitRefID);
    }
