    static void Main(string[] args)
    {
       Int32[] data = new Int32[] { -6, 6, 5, 4, 1, 2, 3, 0, -1, -2, -3, -4, -5 };
       Int32[] index = new Int32[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    
       Array.Sort(data.ToArray(), index);
    
       foreach (Int32 i in index)
       {
          Console.Write(String.Format("{0} ", data[i]));
       }
    
       Console.ReadLine();
    }
