	public static class ExtensionMethods
	{
		public static IEnumerable<Pair<TOuter, TInner>> InnerPair<TInner, TOuter>(this IEnumerable<TOuter> master,
																			 IEnumerable<TInner> minor)
		{
			if (master == null)
				throw new ArgumentNullException("master");
			if (minor == null)
				throw new ArgumentNullException("minor");
			return InnerPairIterator(master, minor);
		}
		public static IEnumerable<Pair<TOuter, TInner>> InnerPairIterator<TOuter, TInner>(IEnumerable<TOuter> master,
																					 IEnumerable<TInner> minor)
		{
			IEnumerator<TOuter> imaster = master.GetEnumerator();
			IEnumerator<TInner> iminor = minor.GetEnumerator();
			while (imaster.MoveNext() && iminor.MoveNext())
			{
				yield return
					new Pair<TOuter, TInner> { First = imaster.Current, Second = iminor.Current };
			}
		}
	}
	public class Pair<TFirst, TSecond>
	{
		public TFirst First { get; set; }
		public TSecond Second { get; set; }
	}
