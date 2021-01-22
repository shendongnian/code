    public class SubmitOrderResult
    {
        private readonly long value_;
        public int OneValue
        { 
            get { return (int)(value_ >> 32); } 
        }
        public int TheOtherValue
        { 
            get { return (int)(value_ & 0xFFFFFFFF); } 
        }
        public SubmitOrderResult(long value)
        { value_ = value; }
    }
