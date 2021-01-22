    namespace LRUCache
    {
        public class LRUCache<K, V>
		{
			public int Capacity { get; }
			Dictionary<K, V> cache;
			K[] keyRingBuffer;
			int ringBufferIndex;
			int LRUIndex => (ringBufferIndex + 1) % Capacity;
			K LRU => keyRingBuffer[LRUIndex];
			public LRUCache(int capacity)
			{
				Capacity = capacity;
				cache = new Dictionary<K, V>(Capacity);
				keyRingBuffer = new K[Capacity];
				ringBufferIndex = 0;
			}
			public bool Contains(K key) => cache.ContainsKey(key);
			public int Size => cache.Count;
			public V Get(K key)
			{
				if (cache.TryGetValue(key, out var value))
				{
					keyRingBuffer[LRUIndex] = key;
					ringBufferIndex = LRUIndex;
					return value;
				}
				throw new Exception($"Element for key {key} not in cache");
			}
			public void Add(K key, V val)
			{
				if (cache.Count >= Capacity) cache.Remove(LRU);
				ringBufferIndex = LRUIndex;
				keyRingBuffer[ringBufferIndex] = key;
				cache.Add(key, val);
			}
		}
    }
