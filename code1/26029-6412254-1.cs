    //Repeats a character specified number of times
    public static string Repeat(char character,int numberOfIterations)
    {
        return "".PadLeft(numberOfIterations, character);
    }
    //Call the Repeat method
    Console.WriteLine(Repeat('\t',40));
