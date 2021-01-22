    interface A<T>
    {
        T Save();
    }
    interface IConcreteInterface : A<IConcreteInterface>
    {
    }
    class BusinessBase<T>
        where T : BusinessBase<T>
    {
        public T Save()
        {
            return (T)this;
        }
    }
    class D<T, U> : BusinessBase<T>
        where T : BusinessBase<T>, A<U>
        where U : A<U>
    {
        public new U Save()
        {
            return (U)(object)base.Save();
        }
    }
    class ConcreteClass : D<ConcreteClass, IConcreteInterface>, IConcreteInterface
    {
    }
