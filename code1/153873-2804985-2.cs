    public abstract class CustomList<T, TList> : where TList : IList<T> {
        protected readonly TList _list;
        
        protected CustomList(TList list) {
            if (list == null)
                throw new ArgumentNullException("list");
            
            _list = list;
            
            foreach (var item in list)
                DoSomething(item);
        }
    }
