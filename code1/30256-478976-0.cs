     public static int SumDigits(int value)
     {
         int sum = 0;
         while (value != 0)
         {
             int rem;
             value = Math.DivRem(value, 10, out rem);
             sum += rem;
         }
         return sum;
     }
    
