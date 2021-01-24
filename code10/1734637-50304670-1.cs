	public class CustomEnumerable : IEnumerable<int>
	{
		public IEnumerator<int> GetEnumerator()
		{
			return new CustomEnumerator();
		}
	
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
