    public enum CompareToOperation
    {
        EqualTo,
        LessThan,
        GreaterThan
    }
    public class CompareToAttribute : ValidationAttribute
    {
        CompareToOperation _Operation;
        string _ComparisionPropertyName1;
        string _ComparisionPropertyName2;
        public CompareToAttribute(CompareToOperation operation, string comparisonPropertyName1, string comparisonPropertyName2)
        {
            _Operation = operation;
            _ComparisionPropertyName1 = comparisonPropertyName1;
            _ComparisionPropertyName2 = comparisonPropertyName2;
        }
        private static IComparable GetComparablePropertyValue(object obj, string propertyName)
        {
            if (obj == null) return null;
            var type = obj.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo == null) return null;
            return propertyInfo.GetValue(obj, null) as IComparable;
        }
        public override bool IsValid(object value)
        {
            var comp1 = GetComparablePropertyValue(value, _ComparisionPropertyName1);
            var comp2 = GetComparablePropertyValue(value, _ComparisionPropertyName2);
            if (comp1 == null && comp2 == null)
                return true;
            if (comp1 == null || comp2 == null)
                return false;
            var result = comp1.CompareTo(comp2);
            switch (_Operation)
            {
                case CompareToOperation.LessThan: return result == -1;
                case CompareToOperation.EqualTo: return result == 0;
                case CompareToOperation.GreaterThan: return result == 1;
                default: return false;
            }
        }
    }
    [CompareTo(CompareToOperation.LessThan, "Start", "End")]
    public class SimpleClass
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
