    using System.Linq;
    var items = new string[] {"Cola", "", "Fanta", null, "Sprite", " "};
    
    string[] nonEmptyItems = items.Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();
    foreach(var nonEmpty in nonEmptyItems) {
        Console.WriteLine(nonEmpty);
    }
