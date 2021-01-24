    public class ScheduleType {
        public static readonly ScheduleType Fixed = new FixedType();
        public static readonly ScheduleType Flexible = new FlexibleType();
        public static readonly ScheduleType FullTime = new FullTimeType();
        public static readonly ScheduleType PartTime = new PartTimeType();
        public static readonly ScheduleType Rotated = new RotatedType();
        public string DisplayName { get { return string.Join(", ", innerValue.Values) + " Work Schedule"; } }
        public int Id { get { return innerValue.Keys.Aggregate((a, b) => a + b); } }
        protected IDictionary<int, string> innerValue = new Dictionary<int, string>();
        protected ScheduleType(int id, string name) {
            innerValue[id] = name;
        }
        protected ScheduleType(ScheduleType a, ScheduleType b) {
            foreach (var kvp in a.innerValue.Union(b.innerValue)) {
                innerValue[kvp.Key] = kvp.Value;
            }
        }
        public ScheduleType And(ScheduleType other) {
            return new ScheduleType(this, other);
        }
        public override bool Equals(object obj) {
            var otherValue = obj as ScheduleType;
            if (otherValue == null) {
                return false;
            }
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);
            return typeMatches && valueMatches;
        }
        public override int GetHashCode() {
            return innerValue.GetHashCode();
        }
        public override string ToString() {
            return DisplayName;
        }
        private class FixedType : ScheduleType {
            public FixedType()
                : base(0x01, "Fixed") {
            }
        }
        private class FlexibleType : ScheduleType {
            public FlexibleType()
                : base(0x02, "Flexible") {
            }
        }
        private class FullTimeType : ScheduleType {
            public FullTimeType()
                : base(0x04, "Full Time") {
            }
        }
        private class PartTimeType : ScheduleType {
            public PartTimeType()
                : base(0x08, "Part Time") {
            }
        }
        private class RotatedType : ScheduleType {
            public RotatedType()
                : base(0x10, "Rotated") {
            }
        }
    }
    
