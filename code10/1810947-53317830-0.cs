	public class TicketStatusComparer : IComparer<string>
	{
		private int GetIntValue( string value )
		{
			switch ( value )
			{
				case "Attended":
					return 1;
				case "Issue":
					return 2;
				case "Unpaid":
					return 3;
			}
			return 0;
		}
		public int Compare( string x, string y )
		{
			return GetIntValue( x ) - GetIntValue( y );
		}
	}
