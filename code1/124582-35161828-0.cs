    public class GetEmployee(String id)
    {
        IEmployee emp = di.GetInstance<List<IEmployee>>().Where(e => e.Id == id).FirstOrDefault();
        emp?.LastAccessTimeStamp = DateTime.Now;
        return emp;
    }
   
