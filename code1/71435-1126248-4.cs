        public T this[int index]
        {
               LinkedListNode<T> current = this.First;
               for (int i = 1; i <= index; i++)
               {
                    current = current.Next;
               }
               return current.value;
        }
