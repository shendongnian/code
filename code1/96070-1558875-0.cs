        public List<List<T>> BatchResultsList<T>(List<T> objectList) 
         where T:SomeInterface, new()
        {
            List<List<T>> toReturn = new List<List<T>>();
            //to instantiate a new T:
            T t = new T();
            foreach (T result in objectList)
            {
                //use result like a SomeInterface instance
            }
            //...
            return toReturn;
        }
