    class ClassZ<T, K>
        where T: IMyInterface, new()
        where K: ClassB, new()
    {
    public T objT;
    public K objK;
        public void funB()
        {
            objT = new T();
            objK = new K();
            objT.fun(objK);
        }
    }
