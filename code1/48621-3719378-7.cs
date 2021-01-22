    namespace LRUCache
    {
        public class LRUCache<K, V>
		{
			public int Capacity { get; }
			private Dictionary<K, V> cacheMap = new Dictionary<K, V>();
			private K[] keyFromIndex;
			private int ringBufferIndex;
			int LRUIndex => (ringBufferIndex + 1) % Capacity;
			public LRUCache(int capacity)
			{
				Capacity = capacity;
				keyFromIndex = new K[Capacity];
				ringBufferIndex = 0;
			}
			public bool Contains(K key) => cacheMap.ContainsKey(key);
			public int Size => cacheMap.Count;
			public V Get(K key)
			{
				if (cacheMap.TryGetValue(key, out var value))
				{
					keyFromIndex[LRUIndex] = key;
					ringBufferIndex = LRUIndex;
					return value;
				}
				throw new Exception($"Element for key {key} not in cache");
			}
			public void Add(K key, V val)
			{
				if (cacheMap.Count >= Capacity) RemoveLeastRecentlyUsed();
				ringBufferIndex = LRUIndex;
				keyFromIndex[ringBufferIndex] = key;
				cacheMap.Add(key, val);
			}
			private void RemoveLeastRecentlyUsed()
			{
				cacheMap.Remove(keyFromIndex[LRUIndex]);
			}
		}
    }
