    public interface IVm
    {
        IVm MyVm { get; set; }
    }
    public class VM : IVm
    {
        public IVm MyVm { get; set; }
        public VM(IExternalEntities externalEntities)
        {
            MyVm = externalEntities.Reflaction.VM;
        }
        public bool IsVmPowerOn()
        {
            //Do something
            return true;
        }
    }
    public interface IExternalEntities
    {
        IReflection Reflaction { get; set; }
    }
    public class ExternalEntities : IExternalEntities
    {
        public IReflection Reflaction { get; set; }
        public ExternalEntities()
        {
            Reflaction = new Reflection();
        }
    }
    public interface IReflection
    {
        IVm VM { get; set; }
    }
    public class Reflection : IReflection
    {
        public IVm VM { get; set; }
        public Reflection()
        {
            VM = new VM(null);
        }
    }
