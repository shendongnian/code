    [TestMethod]
    public void TestChoice() 
    {
        TestChoice("Hello");
        TestChoice(new []{"Hello","World"});
    }
    
    private static void TestChoice(Choice<string[], string> choice)
    {
        string value = choice;
        string[] values = choice;
    
        if (value != null)
            Console.WriteLine("Single value passed in: " + value);
    
        if (values != null) {
            Console.WriteLine("Multiple values passed in ");
            foreach (string s in values)
                Console.WriteLine(s + ",");
        }
    }
