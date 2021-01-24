    public interface ISsn
    {
        string Ssn { get; set; }
    }
    public interface IManagerOf
    {
        List<Employee> Manages { get; set; }
    }
    
    public class Ssn : ISsn { ... }
    public class ManagerOf : IManagerOf { ... }
    
