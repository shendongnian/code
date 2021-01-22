    class UILockable<T> : UIWidget
        where T : UIWidget
    {
        private readonly T t;
    
        public void SomeMethod()
        {
            this.t.SomeMethod();
        }
    }
