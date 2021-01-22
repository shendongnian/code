    foreach( string s in "1,3,5-10,12".Split(',') ) 
    {
        // try and get the number
        int num;
        if( int.TryParse( s, out num ) )
        {
            yield return num;
            continue; // skip the rest
        }
        // otherwise we might have a range
        // split on the range delimiter
        string[] subs = s.Split('-');
        int start, end;
        // now see if we can parse a start and end
        if( subs.Length > 1 &&
            int.TryParse(subs[0], out start) &&
            int.TryParse(subs[1], out end) &&
            end >= start )
        {
            // create a range between the two values
            int rangeLength = end - start + 1;
            foreach(int i in Enumerable.Range(start, rangeLength))
            {
                yield return i;
            }
        }
    }
            
