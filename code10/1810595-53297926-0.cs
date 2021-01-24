    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"Your path to xml");
            FoodData foodData = GetUserData(doc, "David");
            foodData.FoodNames.ForEach(x => Console.WriteLine("Food: " + x));
            Console.WriteLine();
            foodData.DrinkNames.ForEach(x => Console.WriteLine("Drink: " + x));
            Console.ReadLine();
        }
        public static FoodData GetUserData(XDocument doc, string userName)
        {
            FoodData foodData = new FoodData
            {
                FoodNames = doc.Root.Elements(userName).Elements().Where(x => x.Name == "FAVE_FOOD").Descendants().Select(x => x.Attribute("value").Value).ToList(),
                DrinkNames = doc.Root.Elements(userName).Elements().Where(x => x.Name == "FAVE_Drinks").Descendants().Select(x => x.Attribute("value").Value).ToList()
            };
            return foodData;
        }
    }
    public class FoodData
    {
        public List<string> FoodNames { get; set; }
        public List<string> DrinkNames { get; set; }
    }
    
