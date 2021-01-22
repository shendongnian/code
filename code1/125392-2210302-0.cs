    public class AllowedEquipment
    {
        public static AllowedEquiment Warrior()
        {
            return new AllowedEquipment() {
                Daggers = true;
                Swords = true;
                Shields = true;
                Armor = true
            };
        }
        
        public static AllowedEquiment Wizard()
        {
            return new AllowedEquipment() {
                Daggers = true;
                Swords = false;
                Shields = false;
                Armor = true
            };
        }
        
        public bool Daggers { get; set; }
        public bool Swords { get; set; }
        public bool Shields { get; set; }
        public bool Armor { get; set; }
    }
