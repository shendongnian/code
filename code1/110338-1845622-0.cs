    public class Item
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Instance { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("database.txt");
            var list = lines
                    .Select(l =>
                        {
                            var split = l.Split(',');
                            return new Item
                            {
                                ID = int.Parse(split[0]),
                                Type = split[1],
                                Instance = split[2]
                            };
                        });
            
             Item secondItem = list.Where(item => item.ID == 2).Single();
            List<Item> newList = list.ToList<Item>();
            newList.RemoveAll(item => item.ID == 2);
            //override database.txt with new data from "newList"
        }
    }
