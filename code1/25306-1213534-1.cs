    StreamReader leader = new StreamReader(GetReadFile);
    leader.BaseStream.Position = 0;
    StreamReader follower = new StreamReader(GetReadFile);
    	
    int count = 0;
    string tmper = null;
    while (count <= 12)
    {
    	tmper = leader.ReadLine();
    	count++;
    }
    
    long total = follower.BaseStream.Length; // get total length of file
    long step = tmper.Length; // get length of 1 line
    long size = total / step; // divide to get number of lines
    long go = step * (size - 12); // get the bit location
    
    long cut = follower.BaseStream.Seek(go, SeekOrigin.Begin); // Go to that location
    follower.BaseStream.Position = go;
    
    string led = null;
    string[] lead = null ;
    List<string[]> samples = new List<string[]>();
    
    follower.ReadLine();
    
    while (!follower.EndOfStream)
    {
    	led = follower.ReadLine();
    	lead = Tokenize(led);
    	samples.Add(lead);
    }
