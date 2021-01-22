    public class TaskResigstry : Registry
    {
        public TaskResigstry()
        {
            ForRequestedType<IBootstrapperTask>().TheDefaultIsConcreteType<StartTasks>();
    
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.AddAllTypesOf<ITask>();
            });
        }
    }
