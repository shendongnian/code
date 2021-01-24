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
                    // 1a. publish the indended callback, to ensure ctr.Dipose can tell if a wait is necessary.
                    // 1b. transition to the target syncContext and continue there..
                    //  On the target SyncContext.
                    //   2. actually remove the callback
                    //   3. execute the callback
                    // re:#2 we do the remove on the syncCtx so that we can be sure we have control of the syncCtx before
                    //        grabbing the callback.  This prevents a deadlock if ctr.Dispose() might run on the syncCtx too.
                    ...
                 }
            }
         }
       }
    }
