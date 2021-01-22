    public interface IMyInterface
    {
        void DoWork();
    }
    public abstract class MyInterfaceBase : IMyInterface
    {
        /// <summary>
        /// Forced implementation.
        /// </summary>
        protected abstract void DoWork();
        /// <summary>
        /// Explicit implementation.
        /// </summary>
        void IMyInterface.DoWork()
        {
            // Explicit work here.
            this.DoWork();
        }
    }
