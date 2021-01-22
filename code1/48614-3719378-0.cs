    public class LRUCache<K,V>
    {
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public V get(K key)
        {
            LinkedListNode<LRUCacheItem<K, V>> node;
            if (cacheMap.TryGetValue(key, out node))
            {
                //System.Console.WriteLine("Cache HIT " + key);
                V value = node.Value.value;
                lruList.Remove(node);
                lruList.AddLast(node);
                return value;
            }
            //System.Console.WriteLine("Cache MISS " + key);
            return default(V);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void add(K key, V val)
        {
            if (cacheMap.Count >= capacity)
            {
                removeFirst();
            }
            LRUCacheItem<K, V> cacheItem = new LRUCacheItem<K, V>(key, val);
            LinkedListNode<LRUCacheItem<K, V>> node = new LinkedListNode<LRUCacheItem<K, V>>(cacheItem);
            lruList.AddLast(node);
            cacheMap.Add(key, node);
        }
        protected void removeFirst()
        {
            // Remove from LRUPriority
            LinkedListNode<LRUCacheItem<K,V>> node = lruList.First;
            lruList.RemoveFirst();
            // Remove from cache
            cacheMap.Remove(node.Value.key);
        }
        int capacity;
        Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>> cacheMap = new Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>>();
        LinkedList<LRUCacheItem<K, V>> lruList = new LinkedList<LRUCacheItem<K, V>>();
    }
    internal class LRUCacheItem<K,V>
    {
        public LRUCacheItem(K k, V v)
        {
            key = k;
            value = v;
        }
        public K key;
        public V value;
    }
}
