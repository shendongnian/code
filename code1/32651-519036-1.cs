    public interface IHasSharedData
    {
        void UpdateSharedData();
    }
    public abstract class Task
    {
        private static object LockObject = new object();
        protected virtual void UpdateNonSharedData() { }
        public void Method()
        {
             if (this is IHasSharedData)
             {
                lock(LockObject)
                {
                    UpdateSharedData();
                }
             }
             UpdateNonSharedData();
        }
    }
    public class SharedDataTask : Task, IHasSharedData
    {
        public void UpdateSharedData()
        {
           ...
        }
    }
