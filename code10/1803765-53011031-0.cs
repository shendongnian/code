    class Program
    {
     public static void Main(string[] args)
     {
         try
         {
             int a = 2;
             int b = 10 / a;
            if (a == 1)
                a = a / a - a;
            if (a == 2)
            {
                int[] c = { 1 };
                c[8] = 9;
            }
        }
        catch (IndexOutOfRangeException e)
        {
             Console.WriteLine("B");
        }
        finally
        {
            Console.WriteLine("A");
        }
        Console.ReadLine();
    }
    }
