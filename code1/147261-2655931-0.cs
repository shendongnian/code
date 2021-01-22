    sort the array a[n]
    // assuming n > 0
    int iBest = -1;  // index of first number in most popular subset
    int nBest = -1;  // popularity of most popular number
    // for each subset of numbers
    for(int i = 0; i < n; ){
      int ii = i; // ii = index of first number in subset
      int nn = 0; // nn = count of numbers in subset
      // for each number in subset, count it
      for (; i < n && a[i]==a[ii]; i++, nn++ ){}
      // if the subset has more numbers than the best so far
      // remember it as the new best
      if (nBest < nn){nBest = nn; iBest = ii;}
    }
    // print the most popular value and how popular it is
    print a[iBest], nBest
