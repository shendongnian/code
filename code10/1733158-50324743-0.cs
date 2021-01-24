    public enum Race
    {
        Human = 0x01,
        Dwarf = 0x02,
        ...
        Mutant = 0x80,
        Superhuman = Mutant | Human,
        DwarfOnADonkey = Mutant | Dwarf,
        ...
    }
    public abstract Creature
    {
        public abstract Race Race { get; }
        ...
    }
    public abstract NormalCreature : Creature { ... }
    public abstract MutantCreature : Creature { ... }
    public sealed Human : NormalCreature
    {
        public override Race Race { get Race.Human; }
        ...
    }
    public sealed Superhuman : MutantCreature
    {
        public override Race Race { get Race.Superhuman; }
        ...
    }
