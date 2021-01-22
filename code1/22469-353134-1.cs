    public abstract class Metadata
    {
    }
    // extend abstract Metadata class
    public class Metadata<DataType> : Metadata where DataType : struct
    {
        private DataType mDataType;
    }
