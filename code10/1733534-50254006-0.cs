    class Program
        {
            static void Main(string[] args)
            {
                string attrs = "AAA,BBB,CCC,DDD";
                List<Vehicle> vehiclesSort = new List<Vehicle>();
                vehiclesSort.Add(new Vehicle(attrs));
                vehiclesSort.Add(new Vehicle("bbb"));
                vehiclesSort = vehiclesSort.Where(o => o.attr.Contains(attrs)).ToList();
                foreach (var VARIABLE in vehiclesSort)
                {
                    Console.WriteLine(VARIABLE.attr);
                }
            }
        }
        public class Vehicle
        {
            public Vehicle(string attr1)
            {
                this.attr = attr1;
            }
            public string attr;
        }
