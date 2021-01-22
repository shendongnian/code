    public static class Extensions
    {
        public static TReg Parameter<TValue, TReg>(
            this TReg p, string name, TValue value) 
            where TReg : ParameterizedRegistrationBase
        {
            return p;
        }
    }
