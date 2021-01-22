    public enum FruitSize{Small, Medium, Large}
    public enum FruitColor {Red, Green, Blue}
    
      // immutable struct is important for use as dictionary keys
    public struct FruitDescription
    {
        readonly FruitSize _size;
        public FruitSize Size {get{return _size;}}
        readonly FruitColor _color;
        public FruitColor Color { get { return _color; } }
        public FruitDescription(FruitSize size, FruitColor color)
        {
            _size = size;
            _color = color;
        }
    }
        //abstract parent class ...
    public abstract class Fruit
    { public FruitDescription Description {get;set;} }
        //... and children
    public class Apple : Fruit{}
    public class Banana : Fruit{}
    public class Pear : Fruit{}
    public class Basket
    {
        private Dictionary<FruitDescription, Fruit> internalFruits =
            new Dictionary<FruitDescription, Fruit>();
        public void AddFruit(Fruit addme)
        {
            internalFruits[addme.Description] = addme;
        }
        public IEnumerable<FruitDescription> AllDescriptions()
        {
            foreach (FruitSize size in Enum.GetValues(typeof(FruitSize)))
            {
                foreach (FruitColor color in Enum.GetValues(typeof(FruitColor)))
                {
                    FruitDescription desc = new FruitDescription(size, color);
                    yield return desc;
                }
            }
        }
        public Apple GetDefaultApple(FruitDescription desc)
        {
            return new Apple() { Description = desc };
        }
        public IEnumerable<Fruit> GetFruits()
        {
            IEnumerable<Fruit> result = AllDescriptions()
                .Select(desc =>
                  internalFruits.ContainsKey(desc) ?
                  internalFruits[desc] :
                  GetDefaultApple(desc));
            return result;
        }
    }
    public class Pair<T, U>
    {
        public T First { get; set; }
        public U Second { get; set; }
    }
    public class TestClass
    {
        public static void Test()
        {
            Basket b1 = new Basket();
            b1.AddFruit(new Banana() { Description =
                new FruitDescription(FruitSize.Medium, FruitColor.Blue) });
            b1.AddFruit(new Banana() { Description =
                new FruitDescription(FruitSize.Medium, FruitColor.Green) });
            Basket b2 = new Basket();
            b2.AddFruit(new Pear() { Description =
                new FruitDescription(FruitSize.Medium, FruitColor.Green) });
            List<Basket> source = new List<Basket>();
            source.Add(b1);
            source.Add(b2);
            //the main event - a query.
            List<Pair<Fruit, Basket>> result =
            (
              from basket in source
              from fruit in basket.GetFruits()
              select new Pair<Fruit, Basket>()
              { First = fruit, Second = basket }
            ).ToList();
            //a second results structure for fun
            ILookup<Type, Basket> resultByType = result.ToLookup
            (
                p => p.First.GetType(),
                p => p.Second
            );
            Console.WriteLine("Number of fruit: {0}",
                result.Count);
            Console.WriteLine("Number of apples: {0}",
                resultByType[typeof(Apple)].Count());
            Console.WriteLine("Number of baskets with apples: {0}",
                resultByType[typeof(Apple)].Distinct().Count());
            Console.WriteLine("Number of bananas: {0}",
                resultByType[typeof(Banana)].Count());
            Console.WriteLine("Number of baskets with bananas: {0}",
                resultByType[typeof(Banana)].Distinct().Count());
        }
    }
