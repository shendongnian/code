	public class CustomEnumerator : IEnumerator<int>
	{
		public int Current { get; private set; }
		
		object IEnumerator.Current => this.Current;
	
		private int position = 0;
	
		public bool MoveNext()
		{
			position++;
			switch (position)
			{
				case 1:
					Current = 1;
					return true;
				case 2:
					Console.WriteLine("1");
					Current = 2;
					return true;
				default:
					return false;
			}
		}
		
		public void Reset()
		{
			position = 0;
		}
		
		public void Dispose()
		{
			// nothing to do here	
		}
	}
