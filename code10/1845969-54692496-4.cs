        static List<Tech> cars = new List<Tech>();
        public class Tech
        {
            public string Name { get; set; }
            public double KM { get; set; }
        }
        static void Main()
        {
            List<string> moscowCars = new List<string>
                {
                    "GAZ-330811 Aper", "Lada Vesta Sport"
                };
            cars.Add(new Tech() { Name = "Lada Vesta Sport", KM = 190 });
            for (int x = 0; x < cars.Count; x++)
            {
                if (moscowCars.Contains(cars[x].Name))
                {
                    moscowCars.RemoveAt(moscowCars.IndexOf(cars[x].Name));
                }
            }
        }
