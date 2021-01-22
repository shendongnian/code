    namespace ConsoleApplication2 {
        class Program {
            static void Main(string[] args) {
                Print(Enumerable.Range(1, 100).ToList(), 0);
                Console.ReadKey();
                
            }
            public static void Print(List<int> numbers, int currentPosition) {
                Console.WriteLine(numbers[currentPosition]);
                if (currentPosition < numbers.Count - 1) {
                    Print(numbers, currentPosition + 1);
                }
            }
        }
    }
