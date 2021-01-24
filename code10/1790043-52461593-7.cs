	internal abstract class ReportBase
	{
		protected readonly IEnumerable<string> _file;
		public ReportBase(IEnumerable<string> file)
		{
			_file = file;	
		}
		public bool Process()
		{
			return ProcessInternal(_file, ProcessHeader, ProcessDetail, ProcessFooter);
		}
		protected bool ProcessInternal<T>(IEnumerable<T> source, Action<T> first, Action<T> middle, Action<T> last)
		{
			T current = default(T);
			var enumerator = source.GetEnumerator();
			bool ok = enumerator.MoveNext();
			if (!ok) return false; //There were no elements
			var firstElement = enumerator.Current;
			ok = enumerator.MoveNext();
			if (!ok) return false; //There was only 1 element
			first(firstElement);
			while (ok)
			{
				current = enumerator.Current;
				ok = enumerator.MoveNext();
				if (ok) middle(current);
			}
			last(current);
			return true; //At l
		}
		abstract protected void ProcessHeader(string header);
		abstract protected void ProcessDetail(string header);
		abstract protected void ProcessFooter(string header);
	}
