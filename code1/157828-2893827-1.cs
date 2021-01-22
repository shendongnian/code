    public static class Extensions
    {
        public static TReg Parameter<TValue, TReg>(
            this TReg p, string name, TypedValue<TValue> value) 
            where TReg : ParameterizedRegistrationBase
        {
            // can get at value.Value
            return p;
        }
    }
