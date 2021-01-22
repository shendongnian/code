    using System;
    using System.Collections.Generic;
    class MyStack<T> {
        private readonly LinkedList<T> list = new LinkedList<T>();
        public void Push(T value) {
            list.AddLast(value);
        }
        public int Count { get { return list.Count; } }
        public T Pop() {
            LinkedListNode<T> node = list.Last;
            if(node == null) throw new InvalidOperationException();
            list.RemoveLast();
            return node.Value;
        }
        public bool Remove(T item) {
            return list.Remove(item);
        }
    }
