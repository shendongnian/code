    public class Record
    {
        public enum DurationUnit { Minutes, Hours }
        public struct DurationStruct
        {
            public int Value;
            public DurationUnit Unit;
        }
        public DurationStruct Duration; //{get; set;} -can't return a ref to a val type (in C#)
        public void Init()
        {
            Duration.Value = 0;
            Duration.Unit = DurationUnit.Hours;
        }
    }    
