     Parallel.Invoke(() =>
                                     {
                                        if(AObjList.Count > 0)
    {
       aResult = await insertA(AObjList);
      
    }
                                     },  // close first Action
        
                                     () =>
                                     {
                                         if(BObjList.Count > 0)
    {
       bResult = await insertB(BObjList);
      
    }
                                     }
                                 ); //close parallel.invoke
 
