    void Main()
    {
    	using (var stream = new MemoryStream(FakeData().ToArray()))
    	{
    		stream.ScanAOB(0x1, 0x2).Dump("Addresses of: 01 02");
    		stream.Position = 0;
    		stream.ScanAOB(0x03, 0x12).Dump("Addresses of: 03 12");
    		stream.Position = 0;
    		stream.ScanAOB(0x04, null, 0x06).Dump("Addresses of: 04 ?? 06");
    	}
    }
    
    // Define other methods and classes here
    IEnumerable<byte> FakeData()
    {
    	return Enumerable.Range(0, 2)
    		.SelectMany(_ => Enumerable.Range(0, 255))
    		.Select(x => (byte)x);
    }
