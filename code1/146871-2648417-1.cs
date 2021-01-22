    public interface IMyDllObject
    {
       object DllObject { get; set; }
       object GetEligibleEmp(int id);
    }
    
    public class MyDllObject : IMyDllObject
    {
       object DllObject { get; set; }
       object GetEligibleEmp(int id)
       {
           DllObject.GetEligibleEmp(id);
       }
    }
    
    // elsewhere in your code:
    IMyDllObject myDllObject = CreateMyDllObject(); // Factory method, can return test double
    // elsewhere elsewhere
    var eligibleEmp = myDllObject.GetEligibleEmp(id);
