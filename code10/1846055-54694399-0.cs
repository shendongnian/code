    public interface IEmployee
    {
       string WriteNameToDataBase();
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
        public string WriteNameToDataBase()
        {
            var employeeName = nameGetter.GetName();
            return $"Wrote {employeeName.Result} to database";
        }
    }
