    public void BinarySearch(int[] numlist, int value)
        {
            int min = 0;
            int max = numlist.Length - 1;
            int index = -1;
    
            while (min <=max && index == -1)
            {
                int mid = (min + max) / 2;
                if (value > numlist[mid])
                {
                    min = mid + 1;
                }
                else if ( value< numlist[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    index = mid;
                }
            }
            return index;
        }
  
