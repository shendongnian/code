    public interface IMetaData { }
    public class Metadata<DataType> : IMetaData where DataType : struct
    {
        private DataType mDataType;
    }
