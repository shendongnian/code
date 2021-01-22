    public class Record
    {
        public enum DurationUnit { Minutes, Hours }
        public struct DurationStruct
        {
            public readonly int Value;
            public readonly DurationUnit Unit;
            public DurationStruct(int value, DurationUnit unit)
            {
                Value = value;
                Unit = unit;
            }
        }
        public DurationStruct Duration; //{get; set;} -can't return a ref to a val type (in C#)
        public void Init()
        {   
            // initialize struct (not really "new" like a ref type)
            Duration = new DurationStruct(1, DurationUnit.Hours);
        }
    }    
