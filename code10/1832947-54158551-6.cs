    try
    {
       for (int index = 0; index < callbackLists.Length; index++)
       {
          SparselyPopulatedArray<CancellationCallbackInfo> list = Volatile.Read<SparselyPopulatedArray<CancellationCallbackInfo>>(ref callbackLists[index]);
          if (list != null)
          {
             SparselyPopulatedArrayFragment<CancellationCallbackInfo> currArrayFragment = list.Tail;
 
             while (currArrayFragment != null)
             {
                 for (int i = currArrayFragment.Length - 1; i >= 0; i--)
                 {
                    ... some other code
                 }
            }
         }
       }
    }
