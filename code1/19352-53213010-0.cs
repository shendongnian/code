    public interface IDoable
    {
        void Do();
    }
    public class A : IDoable
    {
        public void Hop() 
        {
            // ...
        }
    
        public void Do()
        {
            Hop();
        }
    }
    public class B : IDoable
    {
        public void Skip() 
        {
            // ...
        }
    
        public void Do()
        {
            Skip();
        }
    }
