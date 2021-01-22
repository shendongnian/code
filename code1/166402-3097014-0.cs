    // untested
    int[] values = new int [10];  // all 0's initially
    int sum = 0;
    int pos = 0;
    
    void AddValue (int v)
    {
       sum -= values[pos];  // only need the array to subtract old value
       sum += v;
       values[pos] = v;     
       pos = (pos + 1) % values.length;    
    }
    
    int Average()
    {
       return sum / values.length;
    }
