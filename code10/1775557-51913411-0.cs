    enum Biome
    {
        Forest = 1,
        Desert = 2
    }
    enum Element
    {
        Grass = 1,
        Water = 2,
        Sand = 3
    }
    static readonly Dictionary<(Biome, Element), string> Conditions = new Dictionary<(Biome, Element), string>
    {
        { (Biome.Forest, Element.Grass) , "There is grass in the forest." },
        { (Biome.Forest, Element.Water) , "There is water in the forest." },
        { (Biome.Desert, Element.Sand) , "There is sand in the desert." }
    };
        
    static void Main(string[] args)
    {
        UselessFunction(Biome.Forest, Element.Grass);
        UselessFunction(Biome.Forest, Element.Water);
        UselessFunction(Biome.Forest, (Element)100);
        UselessFunction(Biome.Desert, Element.Sand);
        UselessFunction(Biome.Desert, (Element)100);
        UselessFunction((Biome)100, Element.Grass);
        Console.Read();
    }
    static void UselessFunction(Biome biome, Element element)
    {
        var key = (biome, element);
        if (Conditions.ContainsKey(key))
        {
            Print(Conditions[key]);
        }
        else if (Enum.IsDefined(typeof(Biome), biome))
        {
            Print("Given element is invalid for this biome.");
        }
        else
        {
            Print("Given biome is invalid.");
        }
    }
    static void Print(string message)
    {
        Console.WriteLine(message);
    }
