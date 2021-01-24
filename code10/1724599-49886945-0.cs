    Int32 int32TotalTracksInt;
    string TotalTracks;
    TotalTracks = loadfile.ReadLine();
    Console.WriteLine(TotalTracks);
    Int32 output;
    bool result = Int32.TryParse(TotalTracks, out output);
    if (result)
    {
    	int32TotalTracksInt = output);
    }
    else
    {
    	Console.WriteLine("Comversion failed.");
    	// How you want to handle this situation? 
    	// throw any exception???
    }
