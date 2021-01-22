    /// <summary>
    /// Allows a list of any type to be used to get a result of type TResult
    /// </summary>
    /// <typeparam name="TResult">The result type after using the list</typeparam>
    interface IListUser<TResult>
    {
        TResult Use<T>(List<T> list);
    }
    /// <summary>
    /// Allows a list of any type to be used (with no return value)
    /// </summary>
    interface IListUser
    {
        void Use<T>(List<T> list);
    }
    /// <summary>
    /// Here's a class that can sort lists of any type
    /// </summary>
    class GenericSorter : IListUser
    {
        #region IListUser<Void> Members
        public void Use<T>(List<T> list)
        {
            // do generic sorting stuff here
        }
        #endregion
    }
    
    /// <summary>
    /// Wraps a list of some unknown type.  Allows list users (either with or without return values) to use the wrapped list.
    /// </summary>
    interface IExistsList
    {
        TResult Apply<TResult>(IListUser<TResult> user);
        void Apply(IListUser user);
    }
    /// <summary>
    /// Wraps a list of type T, hiding the type itself.
    /// </summary>
    /// <typeparam name="T">The type of element contained in the list</typeparam>
    class ExistsList<T> : IExistsList
    {
        List<T> list;
        public ExistsList(List<T> list)
        {
            this.list = list;
        }
        #region IExistsList Members
        public TResult Apply<TResult>(IListUser<TResult> user)
        {
            return user.Use(list);
        }
        public void Apply(IListUser user)
        {
            user.Use(list);
        }
        #endregion
    }
    /// <summary>
    /// Your logic goes here
    /// </summary>
    class MyDataGridView
    {
        private IExistsList list;
        public void InitializeData<T>(List<T> list)
        {
            this.list = new ExistsList<T>(list);
        }
        public void Sort()
        {
            list.Apply(new GenericSorter());
        }
    }
