    public static int[] GetFirstEvenNumbers(int count)
    {
        int[] array = new int[count];
        for (int i = 1; i <= array.Length; i++)
            array[i - 1] = i * 2; 
        for (int j = 0; j < count; j++)
            Console.Write(array[j] + " ");                        
        return new int[count];         
    }
    public static void Main(string[] args)
    {
        foreach(var integer in GetFirstEvenNumbers(5))
        {
            Console.WriteLine(integer);
        }
        Console.ReadKey();
    }
