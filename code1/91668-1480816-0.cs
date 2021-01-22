    string str = "dit is een test 1,2,3";
    
    // Length of the string
    int chars = str.Length;
    
    // LINQ: Count all characters that is a number
    int numbers = str.Count(Char.IsNumber);
    
    // LINQ: Split the string on whitespace and count the 
    // elements that contains only letters
    int words = str.Split().Count(s => s.All(Char.IsLetter));
    
    Console.WriteLine(chars); // -> 21
    Console.WriteLine(numbers); // -> 3
    Console.WriteLine(words); // -> 4
