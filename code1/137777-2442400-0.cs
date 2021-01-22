    public class BaseEnum 
    {
        private readonly int m_Value;
        protected BaseEnum( int val ) { m_Value = val; }
        
        public static readonly BaseEnum First  = new BaseEnum(1);
        public static readonly BaseEnum Second = new BaseEnum(2);
        public static readonly BaseEnum Third  = new BaseEnum(3);
    }
    public class DerivedEnum : BaseEnum
    {
        protected DerivedEnum( int val ) : base( val ) { }
        public static readonly DerivedEnum Fourth = new DerivedEnum(4);
        public static readonly DerivedEnum Fifth  = new DerivedEnum(5);
    }
