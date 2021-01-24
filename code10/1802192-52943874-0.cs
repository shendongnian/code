    public enum Fruits {
        Bananas,
        Apples,
        Grapes,
        Blueberries
    }
    public class FruitInfo
    {       
        public Fruits Fruit { get; }
        public decimal Price {get; set}
        ...   
    }
    // TODO: Populate this dictionary with all your fruit info
    private Dictionary<Fruits , FruitInfo> _fruitDatabase;
    
    public FruitInfo ChooseFruit()
    {
        while(true)
        {
            Console.WriteLine("Choose [bananas], [apples], [grapes], or [blueberries]: ");
            var input = Console.ReadLine();
            Fruits selection;
            if(![Enum].TryParse(typeof(Fruits), input, true, out selection))
            {
                Console.Error.WriteLine("Invalid Fruit Selection, Try Again.");
                continue;
            }
            return _fruitDatabase(selection);
        }
    }
    
