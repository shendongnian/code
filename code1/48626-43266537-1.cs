	namespace LruCache
	{
		using System;
		using System.Collections.Generic;
		/// <summary>
		/// A least-recently-used cache stored like a dictionary.
		/// </summary>
		/// <typeparam name="TKey">
		/// The type of the key to the cached item
		/// </typeparam>
		/// <typeparam name="TValue">
		/// The type of the cached item.
		/// </typeparam>
		/// <remarks>
		/// Derived from https://stackoverflow.com/a/3719378/240845
		/// </remarks>
		public class LruCache<TKey, TValue>
		{
			private readonly Dictionary<TKey, LinkedListNode<LruCacheItem>> cacheMap =
				new Dictionary<TKey, LinkedListNode<LruCacheItem>>();
			private readonly LinkedList<LruCacheItem> lruList =
				new LinkedList<LruCacheItem>();
			private readonly Action<TValue> dispose;
			/// <summary>
			/// Initializes a new instance of the <see cref="LruCache{TKey, TValue}"/>
			/// class.
			/// </summary>
			/// <param name="capacity">
			/// Maximum number of elements to cache.
			/// </param>
			/// <param name="dispose">
			/// When elements cycle out of the cache, disposes them. May be null.
			/// </param>
			public LruCache(int capacity, Action<TValue> dispose = null)
			{
				this.Capacity = capacity;
				this.dispose = dispose;
			}
			/// <summary>
			/// Gets the capacity of the cache.
			/// </summary>
			public int Capacity { get; }
			/// <summary>Gets the value associated with the specified key.</summary>
			/// <param name="key">
			/// The key of the value to get.
			/// </param>
			/// <param name="value">
			/// When this method returns, contains the value associated with the specified
			/// key, if the key is found; otherwise, the default value for the type of the 
			/// <paramref name="value" /> parameter. This parameter is passed
			/// uninitialized.
			/// </param>
			/// <returns>
			/// true if the <see cref="T:System.Collections.Generic.Dictionary`2" /> 
			/// contains an element with the specified key; otherwise, false.
			/// </returns>
			public bool TryGetValue(TKey key, out TValue value)
			{
				lock (this.cacheMap)
				{
					LinkedListNode<LruCacheItem> node;
					if (this.cacheMap.TryGetValue(key, out node))
					{
						value = node.Value.Value;
						this.lruList.Remove(node);
						this.lruList.AddLast(node);
						return true;
					}
					value = default(TValue);
					return false;
				}
			}
			/// <summary>
			/// Looks for a value for the matching <paramref name="key"/>. If not found, 
			/// calls <paramref name="valueGenerator"/> to retrieve the value and add it to
			/// the cache.
			/// </summary>
			/// <param name="key">
			/// The key of the value to look up.
			/// </param>
			/// <param name="valueGenerator">
			/// Generates a value if one isn't found.
			/// </param>
			/// <returns>
			/// The requested value.
			/// </returns>
			public TValue Get(TKey key, Func<TValue> valueGenerator)
			{
				lock (this.cacheMap)
				{
					LinkedListNode<LruCacheItem> node;
					TValue value;
					if (this.cacheMap.TryGetValue(key, out node))
					{
						value = node.Value.Value;
						this.lruList.Remove(node);
						this.lruList.AddLast(node);
					}
					else
					{
						value = valueGenerator();
						if (this.cacheMap.Count >= this.Capacity)
						{
							this.RemoveFirst();
						}
						LruCacheItem cacheItem = new LruCacheItem(key, value);
						node = new LinkedListNode<LruCacheItem>(cacheItem);
						this.lruList.AddLast(node);
						this.cacheMap.Add(key, node);
					}
					return value;
				}
			}
			/// <summary>
			/// Adds the specified key and value to the dictionary.
			/// </summary>
			/// <param name="key">
			/// The key of the element to add.
			/// </param>
			/// <param name="value">
			/// The value of the element to add. The value can be null for reference types.
			/// </param>
			public void Add(TKey key, TValue value)
			{
				lock (this.cacheMap)
				{
					if (this.cacheMap.Count >= this.Capacity)
					{
						this.RemoveFirst();
					}
					LruCacheItem cacheItem = new LruCacheItem(key, value);
					LinkedListNode<LruCacheItem> node = 
						new LinkedListNode<LruCacheItem>(cacheItem);
					this.lruList.AddLast(node);
					this.cacheMap.Add(key, node);
				}
			}
			private void RemoveFirst()
			{
				// Remove from LRUPriority
				LinkedListNode<LruCacheItem> node = this.lruList.First;
				this.lruList.RemoveFirst();
				// Remove from cache
				this.cacheMap.Remove(node.Value.Key);
				// dispose
				this.dispose?.Invoke(node.Value.Value);
			}
			private class LruCacheItem
			{
				public LruCacheItem(TKey k, TValue v)
				{
					this.Key = k;
					this.Value = v;
				}
				public TKey Key { get; }
				public TValue Value { get; }
			}
		}
	}
