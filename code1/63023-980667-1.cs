    public interface ILoadable
    {
        void Load(string loadCode);
    }
    public abstract class Item<T> : ItemBase
        where T : ILoadable, new()
    {
        public static T Create(string loadCode)
        {
            T item = new T();
            item.Load(loadCode);
            if (!item.IsEmpty())
            {
                return item;
            }
            else
            {
                throw new CannotInstantiateException();
            }
        }
    }
