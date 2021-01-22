	public class IndexedEventArgs : EventArgs {
		public string Index { get; private set; }
		
		public IndexedEventArgs(string index) {
			Index = index;
		}
		
		// ...
	}
