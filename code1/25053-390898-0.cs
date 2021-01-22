    /// <summary>
    /// Class representing a unit of weight, including how to
    /// convert that unit to kg.
    /// </summary>
    class WeightUnit
    {
        private readonly float conv;
        private readonly string name;
        /// <summary>
        /// Creates a weight unit
        /// </summary>
        WeightUnit(float conv, string name)
        {
            this.conv = conv;
            this.name = name;
        }
        /// <summary>
        /// Returns the name of the unit
        /// </summary>
        public string Name { get { return name; } }
        /// <summary>
        /// Returns the multiplier used to convert this
        /// unit into kg
        /// </summary>
        public float convToKg { get { return conv; } }
    };
    /// <summary>
    /// Class representing a weight, i.e., a number and a unit.
    /// </summary>
    class Weight
    {
        private readonly float value;
        private readonly WeightUnit unit;
        public Weight(float value, WeightUnit unit)
        {
            this.value = value;
            this.unit = unit;
        }
        public float ToFloat()
        {
            return value;
        }
        public WeightUnit Unit
        {
            get { return unit; }
        }
        /// <summary>
        /// Creates a Weight object that is the same value
        /// as this object, but in the given units.
        /// </summary>
        public Weight Convert(WeightUnit newUnit)
        {
            float newVal = value * unit.convToKg / newUnit.convToKg;
            return new Weight(newVal, newUnit);
        }
    };
