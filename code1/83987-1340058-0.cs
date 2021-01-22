    public interface IBranch { }
    public interface ITwig { }
    public class Branch : IBranch
    {
        List<IBranch> _Kids = new List<IBranch>();
        public List<IBranch> Kids
        {
            get { return _Kids; }
        }
        public string Count()
        {
            int b = 0;
            int t = 0;
            int l = 0;
            for (int x = 0; x < _Kids.Count; x++)
            {
                if (_Kids[x] is Branch)
                {
                    b++;
                    // also would need to traverse branch
                }
                else if (_Kids[x] is Twig)
                {
                    t++;
                    // also would need to traverse twig
                }
                else if (_Kids[x] is Leaf)
                {
                    l++;
                }
            }
            return b.ToString() + " branches, " + t.ToString() + " twigs, " + l.ToString() + " leaves.";
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
