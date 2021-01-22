    public class LinkedListEnumerable : IEnumerable<string>
    {
        LinkedList list;
        public LinkedListEnumerable(LinkedList l)
        {
            this.list = l;
        }
    
        public IEnumerator<string> GetEnumerator()
        {
            LinkedList l = list;
            while(l != null)
            {
                yield return l.UniqueKey;
                l = l.Next;
            }
        }
    }
