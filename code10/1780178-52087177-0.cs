    public class Army
    {
        // The army's name
        public string Name { get; set; }
        // List of units in the army
        public List<Unit> Units { get; set; }
        // Get the named unit from this army
        public Unit GetUnit(string name)
        {
            foreach (var unit in this.Units)
            {
                // Case insensitive comparison
                if (string.Compare(unit.Name, name, true) == 0)
                {
                    return unit;
                }
            }
            return null;
        }
    }
    public class Unit
    {
        // The unit's name
        public string Name { get; set; }
        // The unit's attributes
        public List<Attribute> Attributes { get; set; }
        // Get the named attribute from this army
        public Attribute GetAttribute(string name)
        {
            foreach (var attribute in this.Attributes)
            {
                if (string.Compare(attribute.Name, name, true) == 0)
                {
                	return attribute;
                }
            }
            return null;
        }
    }
    public class Attribute
    {
        // The attribute's name
        public string Name { get; set; }
        // Current attribute value and maximum attribute value
        public int CurrentValue { get; set; }
        public int MaxValue { get; set; }
        // Add a value to this attribute and don't let it go above its maximum
        public void Add(int value)
        {
            this.CurrentValue += value;
            if (this.CurrentValue > this.MaxValue)
            {
                this.CurrentValue = this.MaxValue;
            }
        }
    }
    public class Controller
    {
        public List<Army> Armies { get; set; }
        // I'd recommend using string parameters for your buttons instead 
        // of enum parameters, but you can do it either way
        public void ModifyUnitButtonHandler(ArmyTypes army, UnitTypes unit, AttributeTypes attribute, int value)
        {
            // I'm not sure if the ? operator exists in Unity's default .NET version.
            // If not, you can use a few if/then statements to make sure that nothing
            // returns null
            GetArmy(army.ToString())?
                .GetUnit(unit.ToString())?
                .GetAttribute(attribute.ToString())?
                .Add(value);
        }
        private Army GetArmy(string name)
        {
            foreach (var army in this.Armies)
            {
                if (string.Compare(name, army.Name, true) == 0)
                {
                    return army;
                }                
            }
            return null;
        }
    }
