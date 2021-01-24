    Console.Write("Name and surname:");
    string name = Console.ReadLine();
    int word = name.LastIndexOf(" ");
    Console.WriteLine(name.Substring(word+1).ToUpper());
    Console.WriteLine(name.Substring(0, word).ToUpper());
