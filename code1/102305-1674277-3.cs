    public class PreProcessBindingList<T> : BindingList<T>
    {
        public new void Add(T item)
        {
            PreProcess(item);   
            base.Add(item);
        }
    }
