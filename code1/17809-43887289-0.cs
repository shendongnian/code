    public class MostFrequentNumber
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = 0;
            int longestOccurance = 0;
            int mostFrequentNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        counter++;
                    }
                }
                if (counter > longestOccurance)
                {
                    longestOccurance = counter;
                    mostFrequentNumber = numbers[i];
                }
            }
            Console.WriteLine(mostFrequentNumber);
            //Console.WriteLine($"occured {longestOccurance} times");
        }
    }
