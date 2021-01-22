    public event EventHandler SthEvent
    {
        add
        {
            base.Events.AddHandler(EVENT_STH, value);
        }
        remove
        {
            base.Events.RemoveHandler(EVENT_STH, value);
        }
    }
     
    public void AddHandler(object key, Delegate value)
    {
        ListEntry entry = this.Find(key);
        if (entry != null)
        {
            entry.handler = Delegate.Combine(entry.handler, value);
        }
        else
        {
            this.head = new ListEntry(key, value, this.head);
        }
    }
    
     
    public void RemoveHandler(object key, Delegate value)
    {
        ListEntry entry = this.Find(key);
        if (entry != null)
        {
            entry.handler = Delegate.Remove(entry.handler, value);
        }
    }
    
     
    private ListEntry Find(object key)
    {
        ListEntry head = this.head;
        while (head != null)
        {
            if (head.key == key)
            {
                return head;
            }
            head = head.next;
        }
        return head;
    }
    
    private sealed class ListEntry
    {
        // Fields
        internal Delegate handler;
        internal object key;
        internal EventHandlerList.ListEntry next;
    
        // Methods
        public ListEntry(object key, Delegate handler, EventHandlerList.ListEntry next)
        {
            this.next = next;
            this.key = key;
            this.handler = handler;
        }
    }
