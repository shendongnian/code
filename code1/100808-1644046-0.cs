    public static class IRandomExtensions
    {
        public static CodeType GetCode (this IRandom random)
        {
            // 1. get as many random bytes as required
            // 2. transform bytes into a 'Code'
            // 3. bob's your uncle
            ...
        }
    }
        // elsewhere in code
        ...
        OrmObject.Code = random.GetCode ();
        ...
