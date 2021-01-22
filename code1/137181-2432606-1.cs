    public static class Extensions
	{
		public static string ToCSVList<T> ( this T list ) where T : IList
		{
			var sb = new StringBuilder ( list.Count * 36 + list.Count );
			string delimiter = String.Empty;
			foreach ( var document in list )
			{
				string propertyName = document.GetType ().Name.Replace("Document", "ID");
				PropertyInfo property = document.GetType ().GetProperty ( propertyName );
				if ( property != null )
				{
					string value = property.GetValue ( document, null ).ToString ();
					sb.Append ( delimiter + value );
					delimiter = ",";
				}
			}
			return sb.ToString ();
		}
	}
