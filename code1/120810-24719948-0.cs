    public void ReverseIterative()
            {
                if(null == first)
                {
                    return;
                }
                if(null == first.Next)
                {
                    return;
                }
                LinkedListNode<T> p = null, f = first, n = null;
                while(f != null)
                {
                    n = f.Next;
                    f.Next = p;
                    p = f;
                    f = n;
                }
                last = first;
                first = p;
            }
