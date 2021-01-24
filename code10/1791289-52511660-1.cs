    public struct ParameterNameValuePair<TParameterName, TValue>
            {
                private TParameterName  key;
                private TValue value;
                public ParameterNameValuePair(TParameterName parameterName, TValue value)
                {
                     this.key = parameterName;
                     this.value= value;
                }
                public TParameterName ParameterName { get; private set{value = this.key};}
                public TValue Value { get; private private set{value = this.value};}
    //            public override string ToString();
            }
