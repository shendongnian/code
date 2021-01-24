    abstract class DataMold<T>
    {
        public abstract T Result { get; }
        public string ResultString 
        {
            get
            { 
                return Result.ToString();
            }
        }
    }
