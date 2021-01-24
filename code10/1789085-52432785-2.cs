    public class PropertyMetaData : IComparable<PropertyMetaData>
    {
        public PropertyMetaData(PropertyInfo propertyInfo, int inheritanceLevel)
        {
            InheritanceLevel = inheritanceLevel;
            PropertyInfo = propertyInfo;
            AttributeData = propertyInfo.GetCustomAttribute<CustomAttribute>();
        }
        public int InheritanceLevel { get; set; }
        public int OrderWithinClass { get; set; }
        public int OrderOverall { get; set; }
        public CustomAttribute AttributeData { get; set; }            
        public PropertyInfo PropertyInfo { get; set; }
        public int GetOrder()
        {
            return HasCustomOrder() ? AttributeData.Order : this.OrderOverall;
        }
        public bool HasCustomOrder()
        {
            return AttributeData.Order != -1;
        }
        public int CompareTo(PropertyMetaData other)
        {
            var myOrder = GetOrder();
            var otherOrder = other.GetOrder();
            int compare = myOrder.CompareTo(otherOrder);
            if (compare != 0 || other == this) return compare;
            if (HasCustomOrder() && other.HasCustomOrder()) return 0;
            if (HasCustomOrder() && !other.HasCustomOrder()) return -1;
            return 1;
        }
    }
