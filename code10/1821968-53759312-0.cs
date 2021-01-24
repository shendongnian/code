    static void Main(string[] args)
    {
        List<string> questions = Questions();
    
        questions?.ForEach(Console.WriteLine);
    }
    
    private static List<string> Questions()
    {
        List<string> questions = new List<string> {"q1", "q2", "q3"};
    
        return questions;
    }
