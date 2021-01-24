    public class YourClass
    {
        public void YourMethod()
        {
            List<Turbines> newTur = new List<Turbines>
            {
                new Turbines { Turname = "inUK", TurID = 1245, Production = 1452.22, Availability = 52.12 },
                new Turbines { Turname = "InUS", TurID = 125, Production = 1052.22, Availability = 92.12 }
            };
            // 1) passing filter as a lambda
            IEnumerable<Turbines> filteredListWithLambda = newTur.Where(t => t.Availability > 90.0 && t.Production > 1300);
            // 2) passing filter as a method
            IEnumerable<Turbines> filteredListWithMethod = newTur.Where(Filter);
        }
        private bool Filter(Turbines turbines)
        {
            return turbines.Availability > 90.0 && turbines.Production > 1300;
        }
    }
