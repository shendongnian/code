    [ServiceContract]
    public partial interface IBusinessFunctionDAO {
 
    [OperationContract]
    BusinessFunction GetBusinessFunction(Int32 businessFunctionRefID);
    [OperationContract(Action="GetBusinessFunctionProjects")]
    IEnumerable<Project> GetProjects(Int32 businessFunctionRefID);
    }
    [ServiceContract]
    public partial interface IBusinessUnitDAO {
    [OperationContract]
    BusinessUnit GetBusinessUnit(Int32 businessUnitRefID);
    [OperationContract(Action="GetBusinessUnitProjects")]
    IEnumerable<Project> GetProjects(Int32 businessUnitRefID);
    }
