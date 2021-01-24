	public class CustomEnumerator : IEnumerator<int>
	{
		public int Current { get; private set; }
		
		object IEnumerator.Current => this.Current;
	
        // internal 'position' in the sequence, i.e. the current state of the state machine
		private int position = 0;
	
		public bool MoveNext()
		{
            // advance to next state 
            // (works for linear algorithms; an alternative is to select the next state at the end of processing the current state)
			position++;
            // perform the code associated with the current state and produce an element
			switch (position)
			{
                // state 1: line 'yield return 1;'
				case 1:
					Current = 1;
					return true;
                // state 2: lines 'Console.WriteLine("1");' and 'yield return 2;'
				case 2:
					Console.WriteLine("1"); // see also note at the end of this answer
					Current = 2;
					return true;
                // there are no other states in this state machine
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
