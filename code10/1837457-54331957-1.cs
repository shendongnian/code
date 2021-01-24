    public class Spell
    {
        public int castRange;
        public Spell ShallowClone()
        {
            return (Spell)MemberwiseClone();
        }
        public override string ToString() => $"castRange = {castRange}";
    }
    public class ManaSpell : Spell
    {
        public int manaCost;
        public override string ToString() => $"castRange = {castRange}, manaCost = {manaCost}";
    }
