    public interface IProcessable
    {
        public void Process() {....}
    }
    public abstract class ProcessableBase : IProcessable
    {
        public virtual void Process()
        {
            ... standard processing code...
        }
    }
    public class FooProcessable : ProcessableBase
    {
        public override void Process()
        {
            base.Process();
            ... specific processing code
        }
    }
    ...
    IProcessable foo = new FooProcessable();
    foo.Process();
