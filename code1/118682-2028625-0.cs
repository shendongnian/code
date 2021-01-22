    Regex r = new Regex("Apple(d+)\~(d+)\.txt");
    Match mat = r.Match(filename);
    
    if( !mat.Success )
    {
        // Something bad happened...
        return;
    }
    
    int one = int.parse(mat.Groups[0].Value);
    int two = int.parse(mat.Groups[1].Value);
    int num = one + (two-1);
    
    string newFilename = "Apple"+num.ToString("0000")+".txt";
