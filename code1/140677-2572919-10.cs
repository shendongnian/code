    public class PooledFoo : IFoo
    {
        private Foo internalFoo;
        private Pool<IFoo> pool;
        public PooledFoo(Pool<IFoo> pool)
        {
            if (pool == null)
                throw new ArgumentNullException("pool");
            this.pool = pool;
            this.internalFoo = new Foo();
        }
        public void Dispose()
        {
            if (pool.IsDisposed)
            {
                internalFoo.Dispose();
            }
            else
            {
                pool.Release(this);
            }
        }
        public void Test()
        {
            internalFoo.Test();
        }
    }
