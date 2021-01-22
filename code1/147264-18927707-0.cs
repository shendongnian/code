      public static int get_occure(int[] a)
        {
            int[] arr = a;
            int c = 1, maxcount = 1, maxvalue = 0;
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                maxvalue = arr[i];
                for (int j = 0; j <arr.Length; j++)
                {
                    if (maxvalue == arr[j] && j != i)
                    {
                        c++;
                        if (c > maxcount)
                        {
                            maxcount = c;
                            result = arr[i];
                        }
                    }
                    else
                    {
                        c=1;
                   
                    }
                }
    
               
            }
            return result;
        }
  
