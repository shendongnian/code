	void ParseData( string data[], out int[] id, out int[] maxsize, out double[] tax )
	{
		var lines = data.Select( line => line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries) )
						.Select( items => Tuple.Create( int.Parse(items[0]), int.Parse(items[1]), double.Parse(items[2]) ) );
		
		id = lines.Select( s => s.Item1 ).ToArray();
		maxsize = lines.Select( s => s.Item2 ).ToArray();
		tax = lines.Select( s => s.Item3 ).ToArray();
	}
	
	int[] ids;
	int[] maxsizes;
	double[] taxes;
	string[] rawdata = File.ReadAllLines(@"FILENAME");
	
	ParseData( rawdata, out ids, out maxsizes, out taxes );
