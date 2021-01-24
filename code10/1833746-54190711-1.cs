    public static void Main()
    {
       int[] N = new int[]{1,0,6,0,3,4};
    
       Console.WriteLine(string.Join(",", N.RemoveElement(1)));
       Console.WriteLine(string.Join(",", N.RemoveElement(0)));
       Console.WriteLine(string.Join(",", N.RemoveElement(5)));
    }
