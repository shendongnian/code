    namespace LRUCache
    {
        public class LRUCache<K, V>
		{
			private int Capacity { get; }
			private Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>> cacheMap = new Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>>();
			private LinkedList<LRUCacheItem<K, V>> lruList = new LinkedList<LRUCacheItem<K, V>>();
			public LRUCache(int capacity)
			{
				Capacity = capacity;
			}
			public bool Contains(K key) => cacheMap.ContainsKey(key);
			public V Get(K key)
			{
				if (cacheMap.TryGetValue(key, out var node))
				{
					V value = node.Value.Value;
					lruList.Remove(node);
					lruList.AddLast(node);
					return value;
				}
				return default(V);
			}
			public void Add(K key, V val)
			{
				if (cacheMap.Count >= Capacity) RemoveFirst();
				LRUCacheItem<K, V> cacheItem = new LRUCacheItem<K, V>(key, val);
				LinkedListNode<LRUCacheItem<K, V>> node = new LinkedListNode<LRUCacheItem<K, V>>(cacheItem);
				lruList.AddLast(node);
				cacheMap.Add(key, node);
			}
			private void RemoveFirst()
			{
				LinkedListNode<LRUCacheItem<K, V>> node = lruList.First;
				lruList.RemoveFirst();
				cacheMap.Remove(node.Value.Key);
			}
		}
		internal class LRUCacheItem<K, V>
		{
			public K Key { get; }
			public V Value { get; }
			public LRUCacheItem(K k, V v)
			{
				Key = k;
				Value = v;
			}
		}
    }
