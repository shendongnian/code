    public class YourClass
    {
        public void YourMethod(double availability, int production)
        {
            List<Turbines> newTur = new List<Turbines>
            {
                new Turbines { Turname = "inUK", TurID = 1245, Production = 1452.22, Availability = 52.12 },
                new Turbines { Turname = "InUS", TurID = 125, Production = 1052.22, Availability = 92.12 }
            };
            IEnumerable<Turbines> filteredListWithLambda = newTur.Where(t => t.Availability > availability && t.Production > production);
        }
    }
