    public interface IIterface
    {
        void MethodThatShouldWorkAsAlways();
        int MethodToBeTested(int a);
    }
    public class RealClass: IIterface
    {
        public void MethodThatShouldWorkAsAlways()
        { }
        public virtual int MethodToBeTested(int a)
        { return a; }
    }
