    var key = Console.ReadKey();//press 4
    Console.WriteLine("ConsoleKey: " + key.Key); // D4
    Console.WriteLine("Char: " + key.KeyChar); // 4
    Console.WriteLine("ConsoleModifier: " + key.Modifiers); // 0
                
    key = Console.ReadKey(); //press shift + 4
    Console.WriteLine("ConsoleKey: " + key.Key); // D4
    Console.WriteLine("Char: " + key.KeyChar); // $
    Console.WriteLine("ConsoleModifier: " + key.Modifiers); // Shift
