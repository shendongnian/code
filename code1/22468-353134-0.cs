    public abstract class Metadata
    {
    }
    
    public class Metadata<DataType> : MetaData where DataType : struct
    {
        private DataType mDataType;
    }
