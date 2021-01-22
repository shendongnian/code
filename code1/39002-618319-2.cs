	public class AddableArray<T> : IEnumerable<T> {
		private T[] _array;
		public AddableArray(int len) {
			_array = new T[len];
		}
		public AddableArray(params T[] values) : this((IEnumerable<T>)values) {}
		public AddableArray(IEnumerable<T> values) {
			int len;
			if (values is ICollection<T>) {
				len = ((ICollection<T>)values).Count;
			} else {
				len = values.Count();
			}
			_array = new T[len];
			int pos = 0;
			foreach (T value in values) {
				_array[pos] = value;
				pos++;
			}
		}
		public int Length { get { return _array.Length; } }
		public T this[int index] {
			get { return _array[index]; }
			set { _array[index] = value; }
		}
		public static AddableArray<T> operator +(AddableArray<T> a1, AddableArray<T> a2) {
			int len1 = a1.Length;
			int len2 = a2.Length;
			AddableArray<T> result = new AddableArray<T>(len1 + len2);
			for (int i = 0; i < len1; i++) {
				result[i] = a1[i];
			}
			for (int i = 0; i < len2; i++) {
				result[len1 + i] = a2[i];
			}
			return result;
		}
		public IEnumerator<T> GetEnumerator() {
			foreach (T value in _array) {
				yield return value;
			}
		}
		IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return _array.GetEnumerator();
		}
	}
