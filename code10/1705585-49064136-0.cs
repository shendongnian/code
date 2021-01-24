    struct UnsafeLinkedListNode
    {
        public EncodedData value;
        unsafe public UnsafeLinkedListNode* next;
        unsafe public UnsafeLinkedListNode* prev;
    }
    
    class UnsafeLinkedList
    {
    
        unsafe public UnsafeLinkedListNode *head = null;
        unsafe public UnsafeLinkedListNode *tail = null;
        public ulong count { get; private set; }
        unsafe public void AddAfter(EncodedData value)
        {
            UnsafeLinkedListNode temp = new UnsafeLinkedListNode();
            temp.value = value;
            AddAfter(&temp);
        }
        unsafe public void AddAfter(UnsafeLinkedListNode* value)
        {
            unsafe
            {
                if(head !=null)
                {
                    value->prev = tail;
                    value->next = null;
                    tail->next = value;
                    count++;
                    
                }
                else
                {
                    value->next = null;
                    value->prev = null;
                    head = value;
                    tail = value;
                    count++;
                }
            }
        }
    }
