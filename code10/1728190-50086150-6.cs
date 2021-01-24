    public class ScheduleType {
        public static readonly ScheduleType Fixed = new FixedType();
        public static readonly ScheduleType Flexible = new FlexibleType();
        public static readonly ScheduleType FullTime = new FullTimeType();
        public static readonly ScheduleType PartTime = new PartTimeType();
        public static readonly ScheduleType Rotated = new RotatedType();
        public string Name {
            get {
                return string.Join(", ", Types.OrderBy(_ => _.Value).Select(_ => _.Value)) + " Work Schedule";
            }
        }
        public int Value { get { return Types.Keys.Aggregate((a, b) => a + b); } }
        protected IDictionary<int, string> Types = new Dictionary<int, string>();
        protected ScheduleType(int value, string name) {
            Types[value] = name;
        }
        protected ScheduleType(ScheduleType a, ScheduleType b) {
            foreach (var kvp in a.Types.Union(b.Types)) {
                Types[kvp.Key] = kvp.Value;
            }
        }
        public ScheduleType And(ScheduleType other) {
            return new ScheduleType(this, other);
        }
        public bool HasFlag(ScheduleType flag) {
            return Types.ContainsKey(flag.Value);
        }
        public bool HasFlagValue(int value) {
            return Types.ContainsKey(value);
        }
        public override bool Equals(object obj) {
            var otherValue = obj as ScheduleType;
            if (otherValue == null) {
                return false;
            }
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);
            return typeMatches && valueMatches;
        }
        public override int GetHashCode() {
            return Types.GetHashCode();
        }
        public override string ToString() {
            return Name;
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
    
