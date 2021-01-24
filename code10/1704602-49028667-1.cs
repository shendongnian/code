    private unsafe long[] Check(long[] arr1, long[] arr2, int limit)
    {   
       Gpu.FreeAllImplicitMemory(true);
       var gpu = Gpu.Default;    
       var result = new long[arr1.Length];
    
       // Create some pinned memory
       var resultHandle = GCHandle.Alloc(result, GCHandleType.Pinned);
       var arr2Handle = GCHandle.Alloc(result, GCHandleType.Pinned);
       var arr1Handle = GCHandle.Alloc(result, GCHandleType.Pinned);
    
       // get the addresses
       var resultPtr = (int*)resultHandle.AddrOfPinnedObject().ToPointer();
       var arr2Ptr = (int*)arr2Handle.AddrOfPinnedObject().ToPointer();
       var arr1Ptr = (int*)arr2Handle.AddrOfPinnedObject().ToPointer();
    
       // i hate nasty lambda statements i always find local methods easier to read    
       void Workload(int i)
       {
          var found = false;    
          var b = *(arr1Ptr + i);
    
          for (var j = 0; j < arr2.Length; j++)
          {
             if (LibDevice.__nv_popcll(b & *(arr2Ptr + j)) >= limit)
             {
                found = true;
                break;
             }
          }
    
          if (!found)
          {
             *(resultPtr + i) = b;
          }
       }
    
       try
       {
          gpu.For(0, arr1.Length, i => Workload(i));
       }
       finally 
       {
          // make sure we free
          arr1Handle.Free();
          arr2Handle.Free();
          resultHandle.Free();
       } 
       return result;    
    }
