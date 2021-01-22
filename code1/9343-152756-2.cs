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
