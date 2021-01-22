    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
	/// <summary>
	/// A dictionary that maintains insertion ordering of keys.
	/// 
	/// This is useful for emitting JSON where it is preferable to keep the key ordering
	/// for various human-friendlier reasons.
	/// 
	/// There is no support to manually re-order keys or to access keys
    /// by index without using Keys/Values or the Enumerator (eg).
	/// </summary>
    [Serializable]
	public sealed class IndexedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
	{
		// Non-generic version only in .NET 4.5
		private readonly OrderedDictionary _backing = new OrderedDictionary();
		private IEnumerable<KeyValuePair<TKey, TValue>> KeyValuePairs
		{
			get
			{
				return _backing.OfType<DictionaryEntry>()
					.Select(e => new KeyValuePair<TKey, TValue>((TKey)e.Key, (TValue)e.Value));
			}
		}
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return KeyValuePairs.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			_backing[item.Key] = item.Value;
		}
		public void Clear()
		{
			_backing.Clear();
		}
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return _backing.Contains(item.Key);
		}
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			KeyValuePairs.ToList().CopyTo(array, arrayIndex);
		}
		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			TValue value;
			if (TryGetValue(item.Key, out value)
				&& Equals(value, item.Value))
			{
				Remove(item.Key);
				return true;
			}
			return false;
		}
		public int Count
		{
			get { return _backing.Count; }
		}
		public bool IsReadOnly
		{
			get { return _backing.IsReadOnly; }
		}
		public bool ContainsKey(TKey key)
		{
			return _backing.Contains(key);
		}
		public void Add(TKey key, TValue value)
		{
			_backing.Add(key, value);
		}
		public bool Remove(TKey key)
		{
			var result = _backing.Contains(key);
            if (result) {
				_backing.Remove(key);
    		}
			return result;
		}
		public bool TryGetValue(TKey key, out TValue value)
		{
			object foundValue;
			if ((foundValue = _backing[key]) != null
				|| _backing.Contains(key))
			{
				// Either found with a non-null value, or contained value is null.
				value = (TValue)foundValue;
				return true;
			}
			value = default(TValue);
			return false;
		}
		public TValue this[TKey key]
		{
			get
			{
				TValue value;
				if (TryGetValue(key, out value))
					return value;
				throw new KeyNotFoundException();
			}
			set { _backing[key] = value; }
		}
		public ICollection<TKey> Keys
		{
			get { return _backing.Keys.OfType<TKey>().ToList(); }
		}
		public ICollection<TValue> Values
		{
			get { return _backing.Values.OfType<TValue>().ToList(); }
		}
	}
