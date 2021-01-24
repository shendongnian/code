    Public class Employee{
      public int EmpId {get;set;}
      public int EmpName {get;set;}
      public int DistrictId {get;set;}
      public District District {get;set;}
    }
    public class District{
      public int DistrictId {get;set;}
      
      public List<Employee> Employees {get;set;}
    }
