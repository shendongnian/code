    public class Car : Transportation
    {
        //in real life, this might be stored in a database
        private static readonly Dictionary<CarManufacturer, List<string>> CarModels =
            new Dictionary<CarManufacturer, List<string>>
            {
                {CarManufacturer.Acura, new List<string> {"RDX", "NSX", "MDX",}},
                {CarManufacturer.BMW, new List<string> {"2Series", "3Series", "etc",}},
                {CarManufacturer.Honda, new List<string> {"Civic", "Fit", "CRV", "Pilot",}},
                {CarManufacturer.Nissan, new List<string> {"Altima", "Maxima", "Rogue",}},
                {CarManufacturer.Toyota, new List<string> {"Corolla", "Prius",}},
            };
        //these get set at constructor time, they cannot be changed after that
        public CarManufacturer Manufacturer { get; }
        public string Model { get; }
        //you need to call the parameterized base class constructor
        public Car(CarManufacturer manufacturer, string model) : base(Terrain.Land)
        {
            Manufacturer = manufacturer;
            if (!ValidateCarModel(manufacturer, model))
            {
                throw new ArgumentException($"Manufacturer {manufacturer} does not make model: {model}");
            }
            Model = model;
        }
        public static bool ValidateCarModel(CarManufacturer manufacturer, string model)
        {
            if (!CarModels.TryGetValue(manufacturer, out var models))
            {
                return false;
            }
            return models.Contains(model);
        }
        public static IEnumerable<string> ModelsForManufacturer(CarManufacturer manufacturer)
        {
            if (!CarModels.TryGetValue(manufacturer, out var models))
            {
                //maybe this should through, but this also makes sense
                return new List<string>();
            }
            //otherwise
            return models;
        }
    }
