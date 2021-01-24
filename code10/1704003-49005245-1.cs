    public class Class
    {
        public bool Get() => true;
    }
    public interface IFactory
    {
        [ContractAnnotation("=> notnull")]
        Class GetInstance();
    }
    public class Factory : IFactory
    {
        // No redundant ContractAnnotation needed here.
        public Class GetInstance()
        {
            return new Class();
        }
    }
    public class DemoHost
    {
        public void Run()
        {
            IFactory ifactory = new Factory();
            ifactory.GetInstance().Get(); // No null warning here.
            Factory factory = new Factory();
            factory.GetInstance().Get(); // No null warning here as well: obviously the annotation must have been inherited.
        }
    }
