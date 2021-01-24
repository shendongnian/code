    private string fileName = "Final.txt";
    
    public void CustomMethod1()
    {
        Console.WriteLine("Enter the text to save: ");
        string textInput = Console.ReadLine();
    
        try
        {
            File.WriteAllText(this.fileName, textInput);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"You are not allowed to save files in the directory '{this.fileName}'.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"The error '{e.Message}' occured while saving the file.");
        }
    }
    
    public void CustomMethod2()
    {
        if (!File.Exists(this.fileName))
        {
            Console.WriteLine($"Cannot find the file '{this.fileName}'.");
        }
    
        try
        {
            Console.WriteLine("The saved text is: ");
            Console.WriteLine(File.ReadAllText(this.fileName));
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"You are not allowed to read files from the directory '{this.fileName}'.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"The error '{e.Message}' occured while opening the file.");
        }
    }
    
    public static void Main(string[] args)
    {
        Program program = new Program();
        program.CustomMethod1();
        program.CustomMethod2();
    }
