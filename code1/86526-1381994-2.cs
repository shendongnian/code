    internal static class Operations
    {
        // allows null value to function for ease of use at call site
        public static Chain SetRef<T>(this Chain start, string id, T value)
            where T : class
        {
            if (value == null)
                return SetValue(start, id, value.Value);
            else
                return ClearValue(start, id);
        }    
        
        // allows null again
        public static Chain SetValue<T>(this Chain start, string id, T value)
        {
            Chain _prev;
            var existing = Find(start, id, out _prev);        
            if (existing == null)
            {
                return new Node<T>() { Id = id, Next = start, Value = value };
            }
            else
            {
               existing.Value = value;
               return start;
            }
        }
    
        // again null allowed
        public static Chain ClearValue<T>(this Chain start, string id)
        {
            if (start == null)
                return null;
            Chain prev;
            var existing = Find(start, id, out prev);        
            if (existing == null)
            {
                return start;
            }
            else
            {
                if (start == existing)
                    return start.Next;
                prev.Next = existing.Next;
                existing.Next = null;
                return start;
            }
        }
    
        // allows null value to function for ease of use at call site
        public static T GetRef<T>(this Chain start, string id)
            where t: class
        {
            Chain _prev;
            var existing = Find(start, id, out _prev);
            if (existing == null)
                return null;
            return existing.Value;
        }
    
        // allows null value to function for ease of use at call site
        public static T? Get<T>(this Chain start, string id)
            where T : struct
        {
            Chain _prev;
            var existing = Find(start, id, out _prev);
            if (existing == null)
                return null;
            return existing.Value;
        }
    
        private static Node<T> Find<T>(Chain node, string id, out Chain prev)
        {
            prev = null;
            while (node != null)
            {
                if (node.Id.Equals(id))
                    return (Node<T>)node; // add nicer error message
                prev = node; 
            }
        }
    }
