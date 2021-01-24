    class Program
    {
        static void Main(string[] args)
        {
            var goats = new List<Goat>
            {
                {GetProductionStatistics("nubian") },
                {GetProductionStatistics("alpine") },
                {GetProductionStatistics("saanen") } 
            };
            CalculateProductionPotential(goats);
        }
        private static void CalculateProductionPotential(List<Goat> goats)
        {
            foreach (var goat in goats)
            {
                // Process here
            }
        }
        private static Goat GetProductionStatistics(string type)
        {
            var goat = new Goat(); 
            // Some processing... 
            return goat; 
        }
    }
