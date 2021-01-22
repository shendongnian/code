    public class S_LinkedList {
        protected S_Node header = null;
        protected S_Node tail = null;
        public S_LinkedList()
        {
        }
        // METHODS which i don't know how to do it (never use linkedlist before)
        void Insert(Student s)
        {
            if( header == null )
            {
                header = new S_Node(s);
                tail = header;
            }
            else
            {
                tail.Link = new S_Node(s);
                tail = tail.Link;
            }
        }
    }
