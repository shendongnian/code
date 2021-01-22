    namespace LRUCache
    {
        public class LRUCache<K, V>
		{
			public int Capacity { get; }
			Dictionary<K, V> cacheMap = new Dictionary<K, V>();
			K[] keyRingBuffer;
			int ringBufferIndex;
			int LRUIndex => (ringBufferIndex + 1) % Capacity;
			K LRU => keyRingBuffer[LRUIndex];
			public LRUCache(int capacity)
			{
				Capacity = capacity;
				keyRingBuffer = new K[Capacity];
				ringBufferIndex = 0;
			}
			public bool Contains(K key) => cacheMap.ContainsKey(key);
			public int Size => cacheMap.Count;
			public V Get(K key)
			{
				if (cacheMap.TryGetValue(key, out var value))
				{
					keyRingBuffer[LRUIndex] = key;
					ringBufferIndex = LRUIndex;
					return value;
				}
				throw new Exception($"Element for key {key} not in cache");
			}
			public void Add(K key, V val)
			{
				if (cacheMap.Count >= Capacity) cacheMap.Remove(LRU);
				ringBufferIndex = LRUIndex;
				keyRingBuffer[ringBufferIndex] = key;
				cacheMap.Add(key, val);
			}
		}
    }
