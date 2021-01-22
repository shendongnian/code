    class Program {
        static void Main(string[] args) {
    
            string input;
            decimal goal;
            decimal element;
    
            do {
                Console.WriteLine("Please enter the goal:");
                input = Console.ReadLine();
            }
            while (!decimal.TryParse(input, out goal));
    
            Console.WriteLine("Please enter the elements (separated by spaces)");
            input = Console.ReadLine();
            string[] elementsText = input.Split(' ');
            List<decimal> elementsList = new List<decimal>();
            foreach (string elementText in elementsText) {
                if (decimal.TryParse(elementText, out element)) {
                    elementsList.Add(element);
                }
            }
    
            Solver solver = new Solver();
            List<List<decimal>> results = solver.Solve(goal, elementsList.ToArray());
            foreach(List<decimal> result in results) {
                foreach (decimal value in result) {
                    Console.Write("{0}\t", value);
                }
                Console.WriteLine();
            }
    
    
            Console.ReadLine();
        }
    }
