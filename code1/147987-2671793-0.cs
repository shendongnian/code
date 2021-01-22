    List<int> Nums2 = new List<int>();
    for( int i = 1; i < 9; i++ )
       Nums2.Add(i);
    
    for (int i = 1; i < 10; i++)
    {
        Nums2.Insert( 1, Nums2[ Nums2.Count -1] );
        Nums2.RemoveAt(Nums2.Count -1);
    }
