     public class GenericList<T>
    {
       private class Node
        {
            
            public Node(T t)
            {
                next = null;
                data = t;
            }
            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
          
            private T data;
           
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }
        private Node head;
        private Node tail;
        private int count;
       
        public GenericList()
        {
            head = null;
            tail = null;
            count = 0;
        }
     
        public void AddHead(T t)
        {
            if (head == null)
                head = tail = new Node(t);
            else
            {
                Node n = new Node(t);
                n.Next = head;
                head = n;
            }
            count++;
        }
        public void AddTail(T t)
        {
            if(tail == null)
            {
                head = tail = new Node(t);
            }
            else
            {
                Node n = new Node(t);
                tail.Next = n;
                tail = n;
            }
            count++;
        }
        public void InsertAt(T t,int index)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException();
            else if (index == 0)
                AddHead(t);
            else if (index == count)
                AddTail(t);
            else
            {
                Node currentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                Node newNode = new Node(t);
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
            }
            count++;
        }
        public void Reverse()
        {
            if (head == null || head.Next == null)
                return;
            tail = head;
           Node previousNode = null;
           Node currentNode = head;
          Node nextNode = head.Next;
            while (currentNode != null)
            {
                currentNode.Next = previousNode;
                if (nextNode == null)
                    break;
                previousNode = currentNode;
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }
            head = currentNode;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
