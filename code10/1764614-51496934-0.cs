    public interface IFoo
    {
        void B();
    }
    
    public class Bar : IFoo
    {
        void IFoo.B()
        {
        }
    }
