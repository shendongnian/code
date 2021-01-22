    public class Factory<TClass, TInterface> where TClass : TInterface, new()
    {
        public TInterface Create()
        {
            return new TClass();
        }
    }
