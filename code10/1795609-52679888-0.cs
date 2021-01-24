    // Provides a publicly available class.
    // Note, the internal default constructor will only allow derived types from the same assembly, meaning the class is essentially sealed to the outside world
    public class AbcBase
    {
        internal AbcBase()
        {
        }
    
        protected int a;
        protected float pos;
    
        public static List<AbcBase> CreateList()
        {
            return new List<AbcBase>()
            {
                new AbcInternal(1, 2.3f),
                new AbcInternal(4, 5.6f)
            };
        }
    }
    
    internal sealed class AbcInternal : AbcBase
    {
        public AbcInternal(int a, float pos)
        {
            this.a = a;
            this.pos = pos;
        }
    }
