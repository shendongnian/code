    // Create some data
    var stuff = Enumerable.Range(0, 15)
                            .Select(x => (byte)x)
                            .ToArray();
    
    // Create some streams
    var ms1 = new MemoryStream();
    var ms2 = new MemoryStream();
    var ms3 = new MemoryStream();
    
    // write some data to the streams for a test
    ms1.Write(stuff, 0, 5);
    ms2.Write(stuff, 5, 5);
    ms3.Write(stuff, 10, 5);
    
    // make sure we are at the end of the result stream
    ms1.Seek(0, SeekOrigin.End);
    // write the other streams to the result
    ms2.WriteTo(ms1);
    ms3.WriteTo(ms1);
    
    // test its working
    Console.WriteLine(string.Join(", ", ms1.ToArray()));
