    public struct ParameterNameValuePair<TParameterName, TValue>
            {
                private TParameterName  key;
                private TValue value;
                public ParameterNameValuePair(TParameterName parameterName, TValue value)
                {
                     this.key = parameterName;
                     this.value= value;
                }
                public TParameterName ParameterName { get;}
                public TValue Value { get;}
                public override string ToString()
                {
                     return $"Key: {ParameterName.ToString()}, Value:{Value.ToString()}";
                }
            }
