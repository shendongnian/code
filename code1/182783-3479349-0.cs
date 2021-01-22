		private decimal _myDecimalValue = 15.78m;
		public string MyFormattedValue
		{
			get { return _myDecimalValue.ToString("c"); }
			private set;  //makes this a 'read only' property.
		}
