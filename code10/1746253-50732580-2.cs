	public class Music
	{
		private int _volume = 7;
		
		public int Volume
		{
			get { return _volume; }
			set
			{
				if (value >= 0 && value <= 10)
				{
					_volume = value;
				}
			}
		}
	}
