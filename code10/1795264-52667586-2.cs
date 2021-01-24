    //class for test data
    public class Data
    {
        public int    Id               { get; set; }
        public int    Distance         { get; set; }
        public string SlotAvailability { get; set; }
        public override string ToString()
        {
            return $"ID={Id} | Distance={Distance} | SlotAvailability={SlotAvailability}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //test data
            var lst = new List<Data>()
            {
                new Data() {Id = 1, Distance = 5, SlotAvailability  = "yes"},
                new Data() {Id = 2, Distance = 6, SlotAvailability  = "yes"},
                new Data() {Id = 3, Distance = 8, SlotAvailability  = "no"},
                new Data() {Id = 4, Distance = 9, SlotAvailability  = "no"},
                new Data() {Id = 5, Distance = 9, SlotAvailability  = "yes"},
                new Data() {Id = 6, Distance = 9, SlotAvailability  = "in future"},
                new Data() {Id = 7, Distance = 11, SlotAvailability = "in future"},
                new Data() {Id = 8, Distance = 9, SlotAvailability  = "in future"},
            };
            //group the results into chunks
            var groupedList = lst.GroupAdjacent(x => x.Distance)
            //apply the sort logic - this assumes that you only want to sort if there are more or equals to 3 items in the group
            var sortedList = groupedList.SelectMany(x =>
            {
                if (x.Count() < 3) //if the count of the group is below 3 return it as it is
                    return x.AsEnumerable();
                //if the Count is greater or equals to 3 sort the Group by SlotAvailability
                return x.OrderBy(y =>
                {
                    switch (y.SlotAvailability)
                    {
                        case "yes":
                            return 1;
                        case "in future":
                            return 2;
                        case "no":
                            return 3;
                        default:
                            return 0;
                    }
                });
            });
            //print result
            foreach (var data in sortedList)
                Console.WriteLine(data);
            //wait for user input
            Console.ReadKey();
        }
    }
