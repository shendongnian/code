    public static class DoSomething
    {
        public static void Execute<T,K>(K oldObj, K newObj) 
                                          where T : BaseAction<K>, new()
        {
            T action = new T();
            action.Commit(oldObj, newObj);
        }
    }
