    public class TwoKeysDictionary<K1, K2, T>:
			Dictionary<K1, Dictionary<K2, T>>
	{
		public T this[K1 key1, K2 key2]
		{
			get => base.ContainsKey(key1) && base[key1].ContainsKey(key2) ? base[key1][key2] : default;
			set
			{
				if (ContainsKey(key1) && base[key1].ContainsKey(key2))
					base[key1][key2] = value;
				else
					Add(key1, key2, value);
			}
		}
		public void Add(K1 key1, K2 key2, T value)
		{
			if (ContainsKey(key1))
			{
				if (base[key1].ContainsKey(key2))
					throw new Exception("Couple " + key1 + "/" + key2 + " already exists!");
				base[key1].Add(key2, value);
			}
			else
				Add(key1, new Dictionary<K2, T>() { { key2, value } });
		}
		public bool ContainsKey(K1 key1, K2 key2) => ContainsKey(key1) && base[key1].ContainsKey(key2);
	}
