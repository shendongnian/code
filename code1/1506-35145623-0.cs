    // Removes duplicate numbers in place. Returns new length of array.
    public int RemoveDuplicates(ref int[] array)
    {
         int j = 0;
         int count = array.Length;
         if (count > 0)
         {
             for (int i = 1; i < count; ++i)
             {
                 if (array[i - 1] == array[i])
                 {
                     continue;
                 }
    
                 array[j++] = array[i - 1];
             }
     
             if (j > 0)
             {
                 if (array[j - 1] != array[count - 1])
                 {
                     array[j++] = array[count - 1];
                 }
             }
             else
             {
                 ++j;
             }
        }
    
        return j;
    }
