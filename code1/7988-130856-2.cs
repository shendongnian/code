    private int penaltySum(int x, int y, int max)
    {
       int result = int.MaxValue;
            
       checked
       {
           try
           {
               result = x + y;
           }
           catch
           {
               // Arithmetic operation resulted in an overflow.
           }
       }
            
       return result;
}
