    public class CastableObject {
        private UnitOfMeasurement eUnit; // Assign this somehow
        public static implicit operator int(CastableObject obj) 
        {
            if (obj.eUnit != UnitOfMeasurement.Numeric)
            {
                throw new InvalidCastException("Mismatched unit of measurement");
            }
            // return the numeric value
        }
        // Create other cast operators for the other unit types
    }
