    using(StreamReader sr = new StreamReader("filename"))
    {
        var nums = sr.StreamAsSpaceDelimited().Select(s => int.Parse(s));
        var enumerator = nums.GetEnumerator();
        enumerator.MoveNext();
        int numRows = enumerator.Current;
        enumerator.MoveNext();
        int numColumns = enumerator.current;
        int r =0, c = 0;
        int[][] destArray = new int[numRows][numColumns];
        while(enumerator.MoveNext())
        {
            destArray[r][c] = enumerator.Current;
            c++;
            if(c == numColumns)
            {
                c = 0;
                r++;
                if(r == numRows)
                   break;//we are done
            }
        }
