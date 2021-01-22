    class Program {
      static void Main(string[] args) {
          Console.WriteLine(Fitness("hello", "world"));
      }
      static int Fitness(string individual, string target) {
          return Enumerable.Range(0, Math.Min(individual.Length, target.Length))
                           .Count(i => individual[i] == target[i]);
      }
    }
