	public class Program
	{
		private struct EnumeratorWrapper : IEnumerator<int>
		{
			// Fails always --- the local methods read the readonly struct and get a copy
			//private readonly LinkedList<int>.Enumerator m_Enumerator;
			// Fixes one: --- locally, methods no longer get a copy;
			// BUT if a consumer of THIS struct makes a readonly field, then again they will
			// always get a copy of THIS, AND this contains a copy of this struct field!
			private LinkedList<int>.Enumerator m_Enumerator;
			// Fixes both!!
			// Because this is not a value type, even a consumer of THIS struct making a
			// readonly copy, always reads the memory pointer and not a value
			//private IEnumerator<int> m_Enumerator;
			public EnumeratorWrapper(LinkedList<int> linkedList) 
				=> m_Enumerator = linkedList.GetEnumerator();
			
			public int Current
				=> m_Enumerator.Current;
			object System.Collections.IEnumerator.Current
				=> Current;
			public bool MoveNext()
				=> m_Enumerator.MoveNext();
			public void Reset()
				=> ((System.Collections.IEnumerator) m_Enumerator).Reset();
			public void Dispose()
				=> m_Enumerator.Dispose();
		}
		private readonly LinkedList<int> l = new LinkedList<int>();
		private readonly EnumeratorWrapper e;
		public Program()
		{
			for (int i = 0; i < 10; ++i) {
				l.AddLast(i);
			}
			e = new EnumeratorWrapper(l);
		}
		public static void Main()
		{
			Program p = new Program();
			
			// This works --- a local copy every time
			EnumeratorWrapper e = new EnumeratorWrapper(p.l);
			while (e.MoveNext()) {
				Console.WriteLine(e.Current);
			}
			
			// This fails if the struct cannot support living in a readonly field
			while (p.e.MoveNext()) {
				Console.WriteLine(p.e.Current);
			}
			Console.ReadKey();
		}
	}
