    // this remains
    List<Service> svcs = Service.GetServices();
    List<Output> outs = Output.GetOutputs();
    
    svcs[0].OutputCollection.Add(outs);
    svcs[0].Save();
    
    // this changes
    public class Service
    {
        public static List<Service> GetServices()
        {
           var context = new Context();
           var result = context.ServiceSet.ToList();
           result.ForEach(e => context.Detach(e));
           return result;
        }
        public void Save()
        {
           var context = new Context();
           context.Attach(this); // will retach myself and all of my child entities.
           context.SaveChanges();
        }
    }
    
    public class Output
    {
        public static List<Output> GetOutput()
        {
           var context = new Context();
           var result = context.OutputSet.ToList();
           result.ForEach(e => context.Detach(e));
           return result;
        }
    }
