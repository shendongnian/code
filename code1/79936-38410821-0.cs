	using System.Collections;
	using System.Collections.Generic;
	namespace SomeNamespace
	{
		public class ArrayEnumerator<T> : IEnumerator<T>
		{
			public ArrayEnumerator(T[] arr)
			{
				collection = arr;
				length = arr.Length;
			}
			private readonly T[] collection;
			private int index = -1;
			private readonly int length;
			public T Current { get { return collection[index]; } }
			object IEnumerator.Current { get { return Current; } }
			public bool MoveNext() { index++; return index < length; }
			public void Reset() { index = -1; }
			public void Dispose() {/* Nothing to dispose. */}
		}
	}
