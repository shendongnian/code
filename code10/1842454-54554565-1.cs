        using System.Linq;
        ...
        public static void Main(string[] args) {
          Console.Clear();
          // Combine all args with " + "
          string calculation = string.Join(" + ", args);
          // Parse each arg within args then Sum them
          double sum = args.Select(arg => double.Parse(arg)).Sum();
          // Let's use string interpolation to make code be more readable
          Console.WriteLine($"{calculation} = {sum}");
        }
