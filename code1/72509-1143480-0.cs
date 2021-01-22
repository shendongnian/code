      private int GetNextValidSize(int size, int[] validSizes)
      {    
          int returnValue = size;
    
          foreach (int validSize in validSizes)
          {
              if (validSize >= size)
              {
                  return validSizes;
              }
          }
          // Nothing valid    
          return size;
      }
