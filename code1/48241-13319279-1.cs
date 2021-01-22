        public class FIFOStack<T> : LinkedList<T>
        {
            public T Pop()
            {
                T first = First();
                RemoveFirst();
                return first;
            }
            public void Push(T object)
            {
                AddFirst(object);
            }
            //Remove(T object) implemented in LinkedList
       }
