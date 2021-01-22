	public class MyCustomWatcher
	{	
		public event EventHandler Event;
		
		private void RaiseEventForWhateverReason()
		{
			if (Event != null)
			{
				Event(this, new Args());
			}
		}
       public Data GetData()
       {
        //return the data
       }
	}
