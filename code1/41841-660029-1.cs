    static void Main(String[] args)
    {
       Int32[] data = new Int32[] { -6, 6, 5, 4, 1, 2, 3, 0, -1, -2, -3, -4, -5 };
       Int32[] indices = Enumerable.Range(0, data.Length).ToArray();
       Array.Sort(data.ToArray(), indices);
       foreach (Int32 index in indices)
       {
           Console.Write(String.Format("{0} ", data[index]));
       }
       Console.ReadLine();
    }
