    public enum UnitType
    {
        Soldier,
        Mage
    }
    public enum StatType
    {
        MaxHP,
        MaxMP,
        Attack,
        Defense
    }
    // Where the unit initialisation data is stored
    public static class UnitData
    {
        private static Dictionary<string, Dictionary<StatType, int>> Data = new Dictionary<UnitType, Dictionary<StatType, int>>();
        private static string GetKey(UnitType unitType, int level)
        {
            return $"{unitType}:{level}";
        }
        public static AddUnit(UnitType unitType, int level, int maxHP, int maxMP, int attack, int defense)
        {
            Data.Add(GetKey(unitType, level), 
                new Dictionary<StatType, int> 
                {
                    { StatType.MaxHP, maxHP },
                    { StatType.MaxMP, maxMP },
                    { StatType.Attack, attack },
                    { StatType.Defense, defense }
                });
        }
        public static int GetStat(UnitType unitType, int level, StatType statType)
        {
            return Data[GetKet(unitType, level][statType];
        }
    }
    // The data is not stored against the unit but referenced from UnitData
    public class Unit
    {
        public UnitType UnitType { get; private set; }
        public int Level { get; private set; }
        public Unit(UnitType unitType, int level)
        {
            UnitType = unitTypel
            Level = level;
        }
        public int GetStat(StatType statType)
        {
            return UnitData.GetStat(UnitType, Level, statType);
        }
    }
    // To initialise the data
    public class StartClass
    {
        public void InitialiseData()
        {
            UnitData.Add(UnitType.Soldier, 1, 5, 0, 1, 1);
            UnitData.Add(UnitType.Soldier, 2, 6, 0, 2, 2);
            UnitData.Add(UnitType.Soldier, 3, 8, 0, 3, 3);
            UnitData.Add(UnitType.Mage, 1, 3, 10, 1, 1);
            UnitData.Add(UnitType.Mage, 2, 4, 15, 2, 2);
            UnitData.Add(UnitType.Mage, 3, 5, 20, 3, 3);
        }
    }
    // Use of units
    public class Level1
    {
        public List<Unit> Units = new List<Unit>();
        public void InitialiseUnits()
        {
            Units.Add(new Unit(UnitType.Soldier, 1));
            Units.Add(new Unit(UnitType.Soldier, 1));
            Units.Add(new Unit(UnitType.Mage, 1));
            Units.Add(new Unit(UnitType.Mage, 1));
        }
        public void Something()
        {
            int maxHP = Units.First().GetStat(StatType.MaxHP);
            // etc
        }
    }
