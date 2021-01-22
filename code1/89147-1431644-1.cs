    for( int i = 0; i < firstList.Count; i++ )
    {
       firstList[i].IsHit = false;
    
       if( secondList.Contains (firstList[i].Id) )
       {
           secondList.Remove (firstList[i].Id);
           firstList[i].IsHit = true;
       }
    }
