    public static void PerformBruteForce()
    {
        char[] characters = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        int length = 5; // Length of the string created by bruteforce
        int charactersLength = characters.Length;
        int[] odometer = new int[length];
        long size = (long)Math.Pow(charactersLength, length);
    
        for (int i = 0; i < size; i++)
        {
            WriteBruteForce(odometer, characters);
            int position = 0;
            do
            {
                odometer[position] += 1;
                odometer[position] %= charactersLength;
            } while (odometer[position++] == 0 && position < length);
        }
    }
    
    private static void WriteBruteForce(int[] odometer, char[] characters) {
        // Print backwards
        for (int i = odometer.Length - 1; i >= 0; i--) {
            Console.Write(characters[odometer[i]]);
        }
        Console.WriteLine();
    }
