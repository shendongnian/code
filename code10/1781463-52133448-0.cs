    public abstract class BaseClass
    {
        public void DoSomethingDangerous()
        {
            lock (someObject)
            {
                DoDangerous();
            }
        }
        protected virtual void DoDangerous() { }
    }
    
    public class ChildClass : BaseClass
    {
        protected override void DoDangerous() 
        {
            //Do something here
        }
    }
