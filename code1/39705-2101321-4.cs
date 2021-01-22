        public struct KeyValue<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
    
        public class FixedSizeGenericHashTable<K,V>
        {
            private readonly int size;
            private readonly LinkedList<KeyValue<K,V>>[] items;
            
            public FixedSizeGenericHashTable(int size)
            {
                this.size = size;
                items = new LinkedList<KeyValue<K,V>>[size];
            }
    
            protected int GetArrayPosition(K key)
            {
                int position = key.GetHashCode() % size;
                return Math.Abs(position);
            }
    
            public V Find(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K,V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
    
                return default(V);
            }
    
            public void Add(K key, V value)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
                linkedList.AddLast(item);
            }
            public void Remove(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                bool itemFound = false;
                KeyValue<K, V> foundItem = default(KeyValue<K, V>);
                foreach (KeyValue<K,V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemFound = true;
                        foundItem = item;
                    }
                }
                if (itemFound)
                {
                    linkedList.Remove(foundItem);
                }
            }
    
            protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
            {
                LinkedList<KeyValue<K, V>> linkedList = items[position];
                if (linkedList == null)
                {
                    linkedList = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedList;
                }
    
                return linkedList;
            }
        }
