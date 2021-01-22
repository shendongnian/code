	public class Program
	{
		private struct EnumeratorWrapper : IEnumerator<int>
		{
			// Fails
			//private readonly LinkedList<int>.Enumerator m_Enumerator;
			// Fixes one:
			private LinkedList<int>.Enumerator m_Enumerator;
			// Fixes both!!
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
			
			// This works
			EnumeratorWrapper e = new EnumeratorWrapper(p.l);
			while (e.MoveNext()) {
				Console.WriteLine(e.Current);
			}
			
			// This fails
			while (p.e.MoveNext()) {
				Console.WriteLine(p.e.Current);
			}
			Console.ReadKey();
		}
	}
