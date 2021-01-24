    public class ScheduleType : FlagsValueObject<ScheduleType> {
        public static readonly ScheduleType Fixed = new FixedType();
        public static readonly ScheduleType Flexible = new FlexibleType();
        public static readonly ScheduleType FullTime = new FullTimeType();
        public static readonly ScheduleType PartTime = new PartTimeType();
        public static readonly ScheduleType Rotated = new RotatedType();
        protected ScheduleType(int value, string name)
            : base(value, name) {
        }
        private ScheduleType(ScheduleType a, ScheduleType b) {
            foreach (var kvp in a.Types.Union(b.Types)) {
                Types[kvp.Key] = kvp.Value;
            }
        }
        public override string Name {
            get {
                return string.Join(", ", Types.OrderBy(_ => _.Value).Select(_ => _.Value)) + " Work Schedule";
            }
        }
        public override ScheduleType And(ScheduleType other) {
            return new ScheduleType(this, other);
        }
        #region Values
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
        #endregion
    }
    
