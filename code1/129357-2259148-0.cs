    interface IAwesome { // assuming the same interface as in your sample
        T DoSomething<T>();
    }
    class IncrediblyAwesome<T> : IAwesome where T : PonyFactoryFactoryFacade {
        IAwesome.DoSomething<T>() {
            return (T)((object)DoSomething()); // or another conversion, maybe using the Convert class
        }
        public T DoSomething() {
            throw new NotImplementedException();
        }
    }
