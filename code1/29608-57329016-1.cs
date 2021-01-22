    public sealed class Weekday : TypeSafeNameEnum<Weekday, int>
    {
        public static readonly Weekday Monday = new Weekday(1, "--Monday--");
        public static readonly Weekday Tuesday = new Weekday(2, "--Tuesday--");
        public static readonly Weekday Wednesday = new Weekday(3, "--Wednesday--");
        ....
    
        private Weekday(int id, string name) : base(id, name)
        {
        }
    }
