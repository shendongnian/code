        public class Building
        {
            public enum StatusType
            {
                open,
                closed,
                weird,
            };
            public string Name { get; set; }
            public StatusType Status { get; set; }
        }
        public static List <Building> buildingList = new List<Building> ()
        {
            new Building () { Name = "one", Status = Building.StatusType.open },
            new Building () { Name = "two", Status = Building.StatusType.closed },
            new Building () { Name = "three", Status = Building.StatusType.weird },
            new Building () { Name = "four", Status = Building.StatusType.open },
            new Building () { Name = "five", Status = Building.StatusType.closed },
            new Building () { Name = "six", Status = Building.StatusType.weird },
        };
        static void Main (string [] args)
        {
            var statusList = new List<Building.StatusType> () { Building.StatusType.open, Building.StatusType.closed };
            var q = from building in buildingList
                    where statusList.Contains (building.Status)
                    select building;
            foreach ( var b in q )
                Console.WriteLine ("{0}: {1}", b.Name, b.Status);
        }
