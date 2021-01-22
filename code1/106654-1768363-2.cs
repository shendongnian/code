    public interface IBlah
        {
            int GetVal();
        }
    
        public abstract class BlahA : IBlah
        {
            public int GetVal()
            {
                return 1;
            }
    
        }
    
        public class Blah2 : BlahA
        {
        }
    
        public class Blah3 : Blah2
        {
            public List<int> MyList()
            {
                int i = GetVal();
                return new List<int>();
            }
        }
