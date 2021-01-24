    public class ScheduleType : FlagsValueObject<ScheduleType> {
        public static readonly ScheduleType Fixed = new ScheduleType(0x01, "Fixed");
        public static readonly ScheduleType Flexible = new ScheduleType(0x02, "Flexible");
        public static readonly ScheduleType FullTime = new ScheduleType(0x04, "Full Time");
        public static readonly ScheduleType PartTime = new ScheduleType(0x08, "Part Time");
        public static readonly ScheduleType Rotated = new ScheduleType(0x10, "Rotated");
        protected ScheduleType(int value, string name)
            : base(value, name) {
        }
        private ScheduleType(ScheduleType a, ScheduleType b) {
            foreach (var kvp in a.Types.Union(b.Types)) {
                Types[kvp.Key] = kvp.Value;
            }            
            Name = string.Join(", ", Types.OrderBy(kvp => kvp.Value).Select(kvp => kvp.Value)) + " Work Schedule";
            Value = Types.Keys.Sum();
        }
        protected override ScheduleType Or(ScheduleType other) {
            var result=new ScheduleType(this, other);
            //Applying validation rules on new combination
            if (result.HasFlag(Fixed) && result.HasFlag(Rotated))
                throw new InvalidOperationException("ScheduleType cannot be both Fixed and Rotated");
            if (result.HasFlag(FullTime) && result.HasFlag(PartTime))
                throw new InvalidOperationException("ScheduleType cannot be both FullTime and PartTime");
            return result;
        }
    }
