	public static class LoopHelper {
		public static int Index() {
			return (int)HttpContext.Current.Items["LoopHelper_Index"];
		}		
	}
	public static class LoopHelperExtensions {
		public static IEnumerable<T> WithIndex<T>(this IEnumerable<T> that) {
			return new EnumerableWithIndex<T>(that);
		}
		public class EnumerableWithIndex<T> : IEnumerable<T> {
			public IEnumerable<T> Enumerable;
			public EnumerableWithIndex(IEnumerable<T> enumerable) {
				Enumerable = enumerable;
			}
			public IEnumerator<T> GetEnumerator() {
				for (int i = 0; i < Enumerable.Count(); i++) {
					HttpContext.Current.Items["LoopHelper_Index"] = i;
					yield return Enumerable.ElementAt(i);
				}
			}
			IEnumerator IEnumerable.GetEnumerator() {
				return GetEnumerator();
			}
		}
