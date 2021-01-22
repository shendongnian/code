    /// <summary>
    /// Gets the memory cost of a reference type.
    /// </summary>
    /// <param name="type">The type for which to get the cost. It must have a
    /// public parameterless constructor.</param>
    /// <returns>The number of bytes occupied by a default-constructed
    /// instance of the reference type, including any sub-objects it creates
    /// during construction. Returns -1 if the type does not have a public
    /// parameterless constructor.</returns>
    public static int MemoryCost(Type type)
    {
      // Make garbage collection very unlikely during the execution of this function
      GC.Collect();
      GC.WaitForPendingFinalizers();
      
      // Get the constructor and invoke it once to run JIT and any initialization code
      ConstructorInfo constr = type.GetConstructor(Type.EmptyTypes);
      if (constr == null)
        return -1;
      object inst1 = constr.Invoke(null); // 
      
      int size;
      unsafe
      {
        // Create marker arrays and an instance of the type
        int[] a1 = new int[1];
        int[] a2 = new int[1];
        object inst2 = constr.Invoke(null);
        int[] a3 = new int[1];
        
        // Compute the size by determining how much was allocated in between
        // the marker arrays.
        fixed (int* p1 = a1)
        {
          fixed (int* p2 = a2)
          {
            fixed (int* p3 = a3)
            {
              size = (int)(((long)p3 - (long)p2) - ((long)p2 - (long)p1));
            }
          }
        }
      }
      return size;
    }
