    public interface IBranch { }
    public interface ITwig { }
    public class Branch : IBranch
    {
        List<IBranch> _Kids = new List<IBranch>();
        public List<IBranch> Kids
        {
            get { return _Kids; }
        }
    }
    public class Twig : ITwig, IBranch
    {
        List<ITwig> _Kids;
        public List<ITwig> Kids
        {
            get { return _Kids; }
        }
    }
    public class Leaf : ITwig, IBranch
    {
    }
