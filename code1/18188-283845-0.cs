    public class Car
    {
        public int Id {get;set;}
        public string Manufacturer {get;set;}
        public string Model {get;set;}
        public static Car ParseLine(string line)
        {
            string[] parts = line.Split(DELIMITER);
            return new Car
            {
                Id = int.Parse(parts[0]),
                Manufacturer = parts[1],
                Model = parts[2]
            };
        }
    }
