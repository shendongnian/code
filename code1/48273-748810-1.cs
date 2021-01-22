    class BaseGeneric<T>
    {
        private T obj;
        private MethodInfo mi;
        private const string MethodNameOfInterest = "Xyz";
        public BaseGeneric(T theObject)
        {
            this.obj = theObject;
            Type t = obj.GetType();
             mi = t.GetMethod(MethodNameOfInterest);
        }
        public void Xyz()
        {
            mi.Invoke(obj, null);
        }
    }   
