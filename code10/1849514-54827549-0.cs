    public abstract class AbsBase
    {
        public void SomeFunction<T>(T param)
        {
            if (this is IHandle<T> handle)
            {
                handle.Handler(param);
            }
            else
            {
                // Handle error case
            }
        }
    }
