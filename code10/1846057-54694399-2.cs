    public interface IEmployee
    {
       Task<string> WriteNameToDataBase();
    }
   
    public interface INameGetter
    {
       Task<string> GetName();
    }
    public class Employee : IEmployee
    {
         private INameGetter nameGetter;
         public Employee(INameGetter n)
         {
             nameGetter = n;
         }
        public Task<string> WriteNameToDataBase()
        {
            var employeeName = await nameGetter.GetName();
            return $"Wrote {employeeName} to database";
        }
    }
