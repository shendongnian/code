	private class ReverseAdvertisementsComparer: IComparer<Advertisements>
	{
		public int Compare(Advertisements x, Advertisements y)
		{
			// notice: reversed x and y
			return y.Country.Name.CompareTo(x.Country.Name);
		}
	}
