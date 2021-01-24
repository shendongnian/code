    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"Your path to xml");                //<= Load xml
            FoodData foodData = GetUserData(doc, "David");                      //<= Pass "David" to function
            foodData.FoodNames.ForEach(x => Console.WriteLine("Food: " + x));   //<= Print food name list
            Console.WriteLine();
            foodData.DrinkNames.ForEach(x => Console.WriteLine("Drink: " + x)); //<= Print drink name list
            Console.ReadLine();
        }
        public static FoodData GetUserData(XDocument doc, string userName)
        {
            var data = doc.Root.Elements(userName).Elements();
            FoodData foodData = new FoodData
            {
                FoodNames = data.Where(x => x.Name == "FAVE_FOOD").Descendants().Select(x => x.Attribute("value").Value).ToList(),
                DrinkNames = data.Where(x => x.Name == "FAVE_Drinks").Descendants().Select(x => x.Attribute("value").Value).ToList()
            };
            return foodData;
        }
    }
    public class FoodData
    {
        public List<string> FoodNames { get; set; }
        public List<string> DrinkNames { get; set; }
    }
    
