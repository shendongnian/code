    public class Spell
    {
        public int castRange;
        public Spell ShallowClone()
        {
            return (Spell)MemberwiseClone();
        }
        public override string ToString() => $"castRange = {castRange}";
        public static T ShallowClone<T>(T original)
            where T : Spell
        {
            return (T)original.ShallowClone();
        }
    }
