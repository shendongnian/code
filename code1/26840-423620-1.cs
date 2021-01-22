    ToBindingList <T> (...)
---
    public class ListHelper
    {
        public static BindingList<T> ToBindingList<T>(IList<T> data)
        {
            BindingList<T> output = new BindingList<T>();
            foreach (T item in data)
            {
                output.Add(item);
            }
            return output;
        }
    }
