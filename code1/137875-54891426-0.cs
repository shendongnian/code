    /// <summary>
	/// dictionary with double key lookup
	/// </summary>
	/// <typeparam name="T1">primary key</typeparam>
	/// <typeparam name="T2">secondary key</typeparam>
	/// <typeparam name="TValue">value type</typeparam>
	public class cDoubleKeyDictionary<T1, T2, TValue> {
		private struct Key2ValuePair {
			internal T2 key2;
			internal TValue value;
		}
		private Dictionary<T1, Key2ValuePair> d1;
		private Dictionary<T2, T1> d2;
		/// <summary>
		/// add item
		/// not exacly like add, mote like Dictionary[] = overwriting existing values
		/// </summary>
		/// <param name="key1"></param>
		/// <param name="key2"></param>
		public void Add(T1 key1, T2 key2, TValue value) {
			lock (d1) {
				d1[key1] = new Key2ValuePair {
					key2 = key2,
					value = value,
				};
				d2[key2] = key1;
			}
		}
		/// <summary>
		/// get key2 by key1
		/// </summary>
		/// <param name="key1"></param>
		/// <param name="key2"></param>
		/// <returns></returns>
		public bool TryGetValue(T1 key1, out TValue value) {
			if (d1.TryGetValue(key1, out Key2ValuePair kvp)) {
				value = kvp.value;
				return true;
			} else {
				value = default;
				return false;
			}
		}
		/// <summary>
		/// get key1 by key2
		/// </summary>
		/// <param name="key2"></param>
		/// <param name="key1"></param>
		/// <remarks>
		/// 2x O(1) operation
		/// </remarks>
		/// <returns></returns>
		public bool TryGetValue2(T2 key2, out TValue value) {
			if (d2.TryGetValue(key2, out T1 key1)) {
				return TryGetValue(key1, out value);
			} else {
				value = default;
				return false;
			}
		}
		/// <summary>
		/// get key1 by key2
		/// </summary>
		/// <param name="key2"></param>
		/// <param name="key1"></param>
		/// <remarks>
		/// 2x O(1) operation
		/// </remarks>
		/// <returns></returns>
		public bool TryGetKey1(T2 key2, out T1 key1) {
			return d2.TryGetValue(key2, out key1);
		}
		/// <summary>
		/// get key1 by key2
		/// </summary>
		/// <param name="key2"></param>
		/// <param name="key1"></param>
		/// <remarks>
		/// 2x O(1) operation
		/// </remarks>
		/// <returns></returns>
		public bool TryGetKey2(T1 key1, out T2 key2) {
			if (d1.TryGetValue(key1, out Key2ValuePair kvp1)) {
				key2 = kvp1.key2;
				return true;
			} else {
				key2 = default;
				return false;
			}
		}
		/// <summary>
		/// remove item by key 1
		/// </summary>
		/// <param name="key1"></param>
		public void Remove(T1 key1) {
			lock (d1) {
				if (d1.TryGetValue(key1, out Key2ValuePair kvp)) {
					d1.Remove(key1);
					d2.Remove(kvp.key2);
				}
			}
		}
		/// <summary>
		/// remove item by key 2
		/// </summary>
		/// <param name="key2"></param>
		public void Remove2(T2 key2) {
			lock (d1) {
				if (d2.TryGetValue(key2, out T1 key1)) {
					d1.Remove(key1);
					d2.Remove(key2);
				}
			}
		}
		/// <summary>
		/// clear all items
		/// </summary>
		public void Clear() {
			lock (d1) {
				d1.Clear();
				d2.Clear();
			}
		}
		/// <summary>
		/// enumerator on key1, so we can replace Dictionary by cDoubleKeyDictionary
		/// </summary>
		/// <param name="key1"></param>
		/// <returns></returns>
		public TValue this[T1 key1] {
			get => d1[key1].value;
		}
		/// <summary>
		/// enumerator on key1, so we can replace Dictionary by cDoubleKeyDictionary
		/// </summary>
		/// <param name="key1"></param>
		/// <returns></returns>
		public TValue this[T1 key1, T2 key2] {
			set {
				lock (d1) {
					d1[key1] = new Key2ValuePair {
						key2 = key2,
						value = value,
					};
					d2[key2] = key1;
				}
			}
		}
