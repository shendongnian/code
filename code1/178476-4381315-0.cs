    public class Record
    {
        public int ID {get;set;}
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int UnknownIntValue {get;set;}
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UnknownIntKnown {get;set;}
        [SubSonicIgnore]
        public UnknownInt UnknownInt
        {
            get
            {
                return new UnknownInt()
                {
                    val = UnknownIntValue,
                    known = this.UnknownIntKnown
                };
            }
            set
            {
                 this.UnknownIntValue = value.val;
                 this.UnknownIntKnown = value.known;
            }
        }
       
    }
    public struct UnknownInt
    { 
        public readonly int Val;
        public readonly bool Known;
        public UnknownInt(int val, bool known) 
        {
            this.Val = val;
            this.Known = known;
        }
        public override string ToString()
        {
            return String.Format("{0} ({1})",
               Val, Known == true ? "known" : "unknown");
        }
        public override bool Equals(Object obj) 
        {
           return obj is UnknownInt && this == (UnknownInt)obj;
        }
        public static bool operator ==(UnknownInt x, UnknownInt y) 
        {
           return x.Val == y.Val && x.Known == y.Known;
        }
        public static bool operator !=(UnknownInt x, UnknownInt y) 
        {
           return !(x == y);
        }
    }
