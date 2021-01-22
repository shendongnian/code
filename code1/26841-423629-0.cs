    public static class Extensions
    {
        public static BindingList<T> ToBindingList<T>(this IList<T> list) 
        {
            BindingList<T> bindingList = new BindingList<T>();
            foreach (var item in list)
            {
                bindingList.Add(item);
            }
            return bindingList;
        }
    }
