    String result;
    StringBuilder sb = new StringBuilder(10000);   // create a buffer of 10k
    for(int i = 0; i != N; ++i)
    {
       result.AppendString(i.ToString());          // fill the buffer, resizing if it overflows the buffer
    }
    
    result = sb.ToString();   // assigns once
