    class SuperObject { }
    
    class SubObject : SuperObject { }
    
    class WrapperObject<T>:IContravariantInterface<T>,ICovariantInterface<T> where T : SuperObject
    {
        public void DoSomeWork(T obj)
        {
            //todo
        }
    
        public T GetSomeData()
        {
            //todo
            return default;
        }
    }
