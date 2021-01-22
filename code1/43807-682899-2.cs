	public class IndexedList {
		private class Index : Dictionary<string, List<string>> {
			private int _indexLength;
			public Index(int indexLength) {
				_indexLength = indexLength;
			}
			public void Add(string value) {
				if (value.Length >= _indexLength) {
					string key = value.Substring(0, _indexLength);
					List<string> list;
					if (!this.TryGetValue(key, out list)) {
						Add(key, list = new List<string>());
					}
					list.Add(value);
				}
			}
			public IEnumerable<string> Find(string query, int limit) {
				return
					this[query.Substring(0, _indexLength)]
					.Where(s => s.Length > query.Length && s.StartsWith(query))
					.Take(limit);
			}
		}
		private Index _index1;
		private Index _index2;
		private Index _index4;
		private Index _index8;
		public IndexedList(IEnumerable<string> values) {
			_index1 = new Index(1);
			_index2 = new Index(2);
			_index4 = new Index(4);
			_index8 = new Index(8);
			foreach (string value in values) {
				_index1.Add(value);
				_index2.Add(value);
				_index4.Add(value);
				_index8.Add(value);
			}
		}
		public IEnumerable<string> Find(string query, int limit) {
			if (query.Length >= 8) return _index8.Find(query, limit);
			if (query.Length >= 4) return _index4.Find(query,limit);
			if (query.Length >= 2) return _index2.Find(query,limit);
			return _index1.Find(query, limit);
		}
	}
