	public class MultiKeyDictionary<K1, K2, V> : Dictionary<K1, Dictionary<K2, V>>  {
		public V this[K1 key1, K2 key2] {
			get {
				if (!ContainsKey(key1) || !this[key1].ContainsKey(key2))
					throw new ArgumentOutOfRangeException();
				return base[key1][key2];
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new Dictionary<K2, V>();
				this[key1][key2] = value;
			}
		}
		public void Add(K1 key1, K2 key2, V value) {
				if (!ContainsKey(key1))
					this[key1] = new Dictionary<K2, V>();
				this[key1][key2] = value;
		}
		public bool ContainsKey(K1 key1, K2 key2) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2);
		}
 
		public new IEnumerable<V> Values {
			get {
				return from baseDict in base.Values
					   from baseKey in baseDict.Keys
					   select baseDict[baseKey];
			}
		} 
	}
	
	public class MultiKeyDictionary<K1, K2, K3, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, V>> {
		public V this[K1 key1, K2 key2, K3 key3] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, V>();
				this[key1][key2, key3] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, V>();
				this[key1][key2, key3, key4] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, K5, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, K5, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4, K5 key5] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4, key5] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, K5, V>();
				this[key1][key2, key3, key4, key5] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4, key5);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, K5, K6, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, K5, K6, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4, key5, key6] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, K5, K6, V>();
				this[key1][key2, key3, key4, key5, key6] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4, key5, key6);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, K5, K6, K7, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, K5, K6, K7, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4, key5, key6, key7] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, K5, K6, K7, V>();
				this[key1][key2, key3, key4, key5, key6, key7] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4, key5, key6, key7);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, K5, K6, K7, K8, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4, key5, key6, key7, key8] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, V>();
				this[key1][key2, key3, key4, key5, key6, key7, key8] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4, key5, key6, key7, key8);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, K5, K6, K7, K8, K9, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, K9, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4, key5, key6, key7, key8, key9] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, K9, V>();
				this[key1][key2, key3, key4, key5, key6, key7, key8, key9] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4, key5, key6, key7, key8, key9);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, K9, K10, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4, key5, key6, key7, key8, key9, key10] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, K9, K10, V>();
				this[key1][key2, key3, key4, key5, key6, key7, key8, key9, key10] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4, key5, key6, key7, key8, key9, key10);
		}
	}
	public class MultiKeyDictionary<K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, V> : Dictionary<K1, MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, V>> {
		public V this[K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11] {
			get {
				return ContainsKey(key1) ? this[key1][key2, key3, key4, key5, key6, key7, key8, key9, key10, key11] : default(V);
			}
			set {
				if (!ContainsKey(key1))
					this[key1] = new MultiKeyDictionary<K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, V>();
				this[key1][key2, key3, key4, key5, key6, key7, key8, key9, key10, key11] = value;
			}
		}
		public bool ContainsKey(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5, K6 key6, K7 key7, K8 key8, K9 key9, K10 key10, K11 key11) {
			return base.ContainsKey(key1) && this[key1].ContainsKey(key2, key3, key4, key5, key6, key7, key8, key9, key10, key11);
		}
	}
