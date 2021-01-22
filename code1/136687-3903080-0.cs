    // generic linked list node
    public class GenericNode<T>
    {
        public T data;
        public GenericNode<T> nextNode = null;
        public GenericNode(T data)
        {
            this.data = data;
        }
    }
    // generic linked list
    public class GenericLinkedList<T>
    {
        private GenericNode<T> head = null;
        public void Add(T newListItem)
        {
            if (head == null)
            {
                head = new GenericNode<T>(newListItem);
            }
            else
            {
                GenericNode<T> curr = head;
                while (curr.nextNode != null)
                {
                    curr = curr.nextNode;
                }
                curr.nextNode = new GenericNode<T>(newListItem);
            }
        }
        public void DisplayNodes()
        {
            GenericNode<T> curr = head;
            while (curr != null)
            {
                System.Console.WriteLine(curr.data);
                curr = curr.nextNode;
            }
        }
    } 
    class TestGenericLinkedList
    {
        static void Main(string[] args)
        {
            GenericLinkedList<System.Object> gll = new GenericLinkedList<System.Object>();
            gll.Add(12);
            gll.Add("string");
            gll.Add(false);
            gll.DisplayNodes();
        }
    }
}
