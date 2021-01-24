    internal class Role
    {
        public Role(string weapon, string armour, string passive)
        {
            Weapon = weapon;
            Armour = armour;
            Passive = passive;
        }
        public string Weapon { get; }
        public string Armour { get; }
        public string Passive { get; }
        public override string ToString()
        {
            return $"{Weapon}/{Armour}/{Passive}";
        }
    }
