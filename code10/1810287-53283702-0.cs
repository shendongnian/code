    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<int> numbers = new List<int>() {1,2,3,4,5,6,7,8,9 };
            for (int i = 0; i <3; i++)
            {
                int index = i * 3;
                stringBuilder.AppendFormat("{0}{1}{2}", numbers[index], numbers[index + 1], numbers[index + 2]);
                stringBuilder.AppendLine();
            }
            Console.Write(stringBuilder.ToString());
			Console.ReadLine();
        }
    }
