    private static void multiply()
    {
        int[] inputArray = { 2, 3, 6, 8 };
        int[] resultArray = new int[inputArray.Length];
        for ( int i = 0; i < inputArray.Length; i++ )
            Console.Write(inputArray[i] + " ");
        Console.WriteLine();
        for ( int indexInOutput = 0; indexInOutput < resultArray.Length; indexInOutput++ )
        {
            int result = 1;
            for ( int indexInInput = 0; indexInInput < inputArray.Length; indexInInput++ )
            {
                if ( indexInInput != indexInOutput )
                    result *= inputArray[indexInInput];
            }
            resultArray[indexInOutput] = result;
        }
        for ( int i = 0; i < resultArray.Length; i++ )
            Console.Write(resultArray[i] + " ");
    }
