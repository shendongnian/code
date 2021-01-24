    public static int[] GetNumbers()
    {
        Console.WriteLine("Enter Numbers Seperated With a Space");
        string input = Console.ReadLine();
        string[] arr = input.Split(' ');
        int[] output = new int[arr.Length];
      
        for(int i = 0; i < output.Length; i++)
        {
            output[i] = Int32.Parse(arr[i]);
        }
        return output;
    }
