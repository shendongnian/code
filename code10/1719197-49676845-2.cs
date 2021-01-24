    public interface IPerformerFactory
    {
         IPerformer Create(int id, string name)
    }
    kernel.Bind<IPerformer>().To<MyClass>();
    kernel.Bind<IPerformerFactory>().ToFactory();
