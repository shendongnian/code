    public IEmployee GetEmployee(string id)
    {
        IEmployee emp = di.GetInstance<List<IEmployee>>().Where(e => e.Id == id).FirstOrDefault();
        emp?.LastAccessTimeStamp = DateTime.Now;
        return emp;
    }
   
