	public class CountingList
	{
	    Dictionary<string, int> countingList = new Dictionary<string, int>();
	   void Add( string s )
	   {
			if( countingList.ContainsKey( s ))
			     countingList[ s ] ++;
		    else
			    countingList.Add( s, 1 );
	   }
	}
