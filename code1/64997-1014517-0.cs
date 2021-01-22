        public class CustomStack<T>
        {
            private LinkedList<T> list;
            public CustomStack()
            {
                list = new LinkedList<T>();
            }
            public void Push(T item)
            {
                list.AddFirst(item);
            }
            public T Pop()
            {
                var result = list.First.Value;
                list.RemoveFirst();
                return result;
            }
            public void TrimLast(int amountToLeave)
            {
                while (list.Count > amountToLeave)
                {
                    list.RemoveLast();
                }
            }
        }
