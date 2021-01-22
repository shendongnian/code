    int[] values = new int[ Integer.MAX ]; // initialize with 0
    int size1 = list1.size();
    int size2 = list2.size();
    for( int pos = 0; pos < size1 + size2 ; pos++ )
    {
         int val =  pos > size1 ? list2[ pos-size1 ] : list1[ pos ] ;
         values[ val ]++;
    }
