	public sealed class ExtensionComparer : IComparer<string>
	{
		private readonly CultureInfo m_CultureInfo;
		private readonly CompareOptions m_CompareOptions;
		public ExtensionComparer() : this( CultureInfo.CurrentUICulture, CompareOptions.None ) {}
		public ExtensionComparer( CultureInfo cultureInfo, CompareOptions compareOptions )
		{
			m_CultureInfo = cultureInfo;
			m_CompareOptions = compareOptions;
		}
		public int Compare( string filePath1, string filePath2 )
		{
			if( filePath1 == null || filePath2 == null )
			{
				if( filePath1 != null )
				{
					return 1;
				}
				if( filePath2 != null )
				{
					return -1;
				}
				return 0;
			}
			var i = filePath1.LastIndexOf( '.' ) + 1;
			var j = filePath2.LastIndexOf( '.' ) + 1;
			if( i == 0 || j == 0 )
			{
				if( i != 0 )
				{
					return -1;
				}
				return j != 0 ? 1 : 0;
			}
			while( true )
			{
				if( i == filePath1.Length || j == filePath2.Length )
				{
					if( i != filePath1.Length )
					{
						return -1;
					}
					return j != filePath2.Length ? 1 : 0;
				}
				var compareResults = string.Compare( filePath1[i].ToString(), filePath2[j].ToString(), m_CultureInfo, m_CompareOptions );
				//var compareResults = filePath1[i].CompareTo( filePath2[j] );
				if( compareResults != 0 )
				{
					return compareResults;
				}
				i++;
				j++;
			}
		}
	}
