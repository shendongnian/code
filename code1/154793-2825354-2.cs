    public delegate int Transformer (int x);
    class Util
    {
       public static void Transform (int[] values, Transformer t)
       {
          for (int i = 0; i < values.Length; i++)
          values[i] = t (values[i]);
       }
    }
    class Test
    {
       static void Main()
       {
          int[] values = { 1, 2, 3 };
          Util.Transform (values, Square); // Dynamically hook in Square
          foreach (int i in values)
             Console.Write (i + " "); // 1 4 9
       }
       static int Square (int x) { return x * x; }
    }
