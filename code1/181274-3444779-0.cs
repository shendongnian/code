    class CElement
    {
        public int? attack { get; set; }
        public int? base { get; set; }
        public int? block { get; set; }
        public int? effective { get; set; }
        public int? petBonus { get; set; }
        public int? mana { get; set; }
        public int? healthRegen { get; set; }
        public int? manaRegen { get; set; }
    
        public double? critHitPercent { get; set; }
        public double? percent { get; set; }
    }
    class CBaseStats
    {
        public CElement strength;
        public CElement agility;
        public CElement stamina;
        public CElement intellect;
        public CElement spirit;
        public CElement armor;
    }
