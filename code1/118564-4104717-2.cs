    class myclass
    {
         public static void Main(string[] args)
         {
             unsafe
             {
                 int iData = 10;
                 int* pData = &iData;
                 Console.WriteLine("Data is " + iData);
                 Console.WriteLine("Address is " + (int)pData);
             }
         }
    }
