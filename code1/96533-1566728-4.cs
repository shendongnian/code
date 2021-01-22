        public class Building
        {
            public enum StatusType
            {
                open,
                closed,
                weird,
            };
            public string Name { get; set; }
            public string Status { get; set; }
        }
        public static List <Building> buildingList = new List<Building> ()
        {
            new Building () { Name = "one", Status = "open" },
            new Building () { Name = "two", Status = "closed" },
            new Building () { Name = "three", Status = "weird" },
            new Building () { Name = "four", Status = "open" },
            new Building () { Name = "five", Status = "closed" },
            new Building () { Name = "six", Status = "weird" },
        };
        static void Main (string [] args)
        {
            var statusList = new List<Building.StatusType> () { Building.StatusType.open, Building.StatusType.closed };
            var statusStringList = statusList.ConvertAll <string> (st => st.ToString ());
            var q = from building in buildingList
                    where statusStringList.Contains (building.Status)
                    select building;
            foreach ( var b in q )
                Console.WriteLine ("{0}: {1}", b.Name, b.Status);
            Console.ReadKey ();
        }
