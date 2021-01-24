    public struct ParameterNameValuePair<TParameterName, TValue>
            {
                private TParameterName  key;
                private TValue value;
                public ParameterNameValuePair(TParameterName parameterName, TValue value)
                {
                     this.key = parameterName;
                     this.value= value;
                }
                public TParameterName ParameterName { get; private set;}
                public TValue Value { get; private set;}
    //            public override string ToString();
            }
