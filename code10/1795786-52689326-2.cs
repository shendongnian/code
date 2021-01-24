    public class Species
    {
        // species name, e.g. 'Human', 'Orc'
        public string Name { get; set; }
        public int NumberOfLegs { get; set; }
        // if SkinColorEnum is a [Flags]-enum, then it can have multiple values here
        public SkinColorEnum SkinColor { get; set; }
    }
    public class Creature
    {
        // the species of this creature
        public Species Species { get; set; }
        // creature name, e.g. 'Adam', 'Eve', or `Balogog` (an orc)
        public string Name { get; set; }
        // we assume only a single skin color value is used, even though SkinColorEnum were a Flags
        public SkinColorEnum SkinColor { get; set; }
    }
