    public struct ParameterNameValuePair<TParameterName, TValue>
    {
        public ParameterNameValuePair(TParameterName parameterName, TValue value)
        {
            ParameterName = parameterName;
            Value = value;
        }
        public TParameterName ParameterName { get; private set; }
        public TValue Value { get; private set; }
    }
