	public class Map<T1, T2>
	{
		private object _gate = new object();
		private Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
		private Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();
	
		public Map()
		{
			this.Forward = new Indexer<T1, T2>(_gate, _forward);
			this.Reverse = new Indexer<T2, T1>(_gate, _reverse);
		}
	
		public class Indexer<T3, T4>
		{
			private object _gate;
			private Dictionary<T3, T4> _dictionary;
			public Indexer(object gate, Dictionary<T3, T4> dictionary)
			{
				_dictionary = dictionary;
				_gate = gate;
			}
			public T4 this[T3 index]
			{
				get { lock (_gate) { return _dictionary[index]; } }
				set { lock (_gate) { _dictionary[index] = value; } }
			}
		}
	
		public void Add(T1 t1, T2 t2)
		{
			lock (_gate)
			{
				_forward.Add(t1, t2);
				_reverse.Add(t2, t1);
			}
		}
	
		public Indexer<T1, T2> Forward { get; private set; }
		public Indexer<T2, T1> Reverse { get; private set; }
	}
