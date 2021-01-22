    interface IThing {
        Decimal Weight { get; set; }
        Decimal Velocity { get; set; }
        Decimal Distance { get; set; }
        Decimal Age { get; set; }
        Decimal AnotherValue { get; set; }
    }
    delegate Decimal PropertyValue(IThing thing);
    public class ThingList : IList<IThing> {
        public Decimal Max(PropertyValue prop) {
            Decimal result = Decimal.MinValue;
            foreach (IThing thing in this) {
                result = Math.Max(result, prop(thing));
            }
            return result;
        }
    }
