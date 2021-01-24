    static void Main()
    {
        int[] arr = new int[] { 0, 1, 2, 3, 4, 5 };
        Console.WriteLine(string.Join(" ",arr));
        
        Array.ForEach(arr, (n) => {
            n++;
        });
        Console.WriteLine(string.Join(" ",arr));
    }
