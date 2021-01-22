    using System;
    static class Program
    {
        static T[][] Split<T>(this T[] arrayIn, int length)
        {
            bool even = arrayIn.Length%length == 0;
            int totalLength = arrayIn.Length/length;
            if (!even)
                totalLength++;
            T[][] newArray = new T[totalLength][];
            for (int i = 0; i < totalLength;++i )
            {
                int allocLength = length;
                if (!even && i == totalLength - 1)
                    allocLength = arrayIn.Length % length;
                newArray[i] = new T[allocLength];
                Array.Copy(arrayIn, i * length, newArray[i], 0, allocLength);
            }
            return newArray;
        }
        static void Main(string[] args)
        {
            int[] numbers = new int[8010];
            for (int i = 0; i < numbers.Length; ++i)
                numbers[i] = i;
            int[][] sectionedNumbers = numbers.Split(1000);
            Console.WriteLine("{0}", sectionedNumbers.Length);
            Console.WriteLine("{0}", sectionedNumbers[7].Length);
            Console.WriteLine("{0}", sectionedNumbers[1][0]);
            Console.WriteLine("{0}", sectionedNumbers[7][298]);
            Console.ReadKey();
        } 
    }
