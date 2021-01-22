    public struct SubmitOrderResult
    {
        private long _result;
    
        public SubmitOrderResult(long result)
        {
            _result = result;
        }
    
        public long Result
        {
            get { return _result; }
            set { _result = value; }
        }
    
        public int GetHigherValue()
        {
            return (int)(_result >> 32);
        }
    
        public int GetLowerValue()
        {
            return (int)_result;
        }
        
        public static implicit operator SubmitOrderResult(long result)
        {
            return new SubmitOrderResult(result);
        }
        public static implicit operator long(SubmitOrderResult result)
        {
            return result._result;
        }
    }
