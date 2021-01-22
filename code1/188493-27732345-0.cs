	public class MockDataReader : IDataReader
	{
		private int _rowCounter = 0;
		private List<Dictionary<string,object>> _records = new List<Dictionary<string,object>>();
		
		public MockDataReader(List<Dictionary<string,object>> records)
		{
			_records = records;
		}
		
		public bool Read()
		{
			_rowCounter++;
			if (_rowCounter < _records.Count) return true;
			return false;
		}
		
		public object this[string name]
		{
			get { return _records[_rowCounter][name]; }
		}
	}
