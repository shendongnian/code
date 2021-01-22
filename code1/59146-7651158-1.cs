    public class NotificationList<T> : IList, IList<T>    
    {
        IList<T> myList;
        public NotificationList(IList<T> list)
        {
            myList = list;
        }
        int IList.Add(object item)
        {
            myList.Add ((T) item);
        } 
        // implement both IList<T> and IList
        // ...
    }
