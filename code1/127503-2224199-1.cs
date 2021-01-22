    class CharacterType
    {
        public readonly List<Skill> Skills = new List<Skill>();
    }
    class Character
    {
        public IEnumerable<Skill> Skills { get { return mType.Skills; } }
        
        private CharacterType mType;
    }
