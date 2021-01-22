    // P.S. to be ultra efficient 
    // make a good guess at the initial allocation too !!!!
    int PerWhatever_SizeEstimate = 4; // a guess of average length... you known your data
    StringBuilder sb = new StringBuilder( whateverlist.Length * PerWhatever_SizeEstimate);
    // reallocation needed? 
    // if you want to be efficient speed and memory wise... 
    sb.Length = 0;  // rest internal index but don't release/resize memory
    // if a ...BIG... difference in size
    if( whatever2.Length < whatever.Length * 2/3  
     || whatever2.Length > whatever.Length * 1.5)
    {
        //scale capacity appropriately
        sb.Capaciy = sb.Capacity * whatever2.Length / whatever.Length;
    }
