    public class Record
    {
        public enum DurationUnit { Minutes, Hours }
        public struct DurationStruct
        {
            public int Value;
            public DurationUnit Unit;
        }
        public DurationStruct Duration //{get; set;} - can't return ref of val type
        public void Init()
        {
            Duration.Value = 0;
        }
    }    
