    abstract class BaseDataFormat
    { 
        BaseDataFormat(int dataLength)
        {
            DataLength = dataLength;
        }
    
        public int DataLength { get; private set; }
        abstract void InitalizeFromBytes(byte [] );
    }
    
    class DataFormat1 : BaseDataFormat
    {
        public DataFormat1() : base(3)
        {
            // ...
        }
    }
