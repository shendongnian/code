    public struct ParameterNameValuePair<TParameterName, TValue>
    {
        public ParameterNameValuePair(TParameterName parameterName, TValue value)
        {
            ParameterName = parameterName;
            Value = value;
        }
        public TParameterName ParameterName { get; }
        public TValue Value { get; }
        public override string ToString()
        {
            return $"Parameter={ParameterName}, Value={Value}";
        }
    }
