	private class PlaceHolder
	{
		public string Name { get; }//This property is the DisplayMember of both ComboBoxes.
		public List<PlaceHolder> Areas { get { return new List<PlaceHolder>(0); } }//This property is the ValueMember of datasetList.
	}
