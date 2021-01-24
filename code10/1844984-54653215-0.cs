static void Main(string[] args)
{
    PotentialEmployee pe = new PotentialEmployee();
    using (StreamReader InterviewQuestions = new StreamReader(@"C:\temp\Questions.txt"))
    {
        string question;
        while ((question = InterviewQuestions.ReadLine()) != null)
        {
            Console.WriteLine(question);
            string response = Console.ReadLine();
            pe.Responses.Add(question, response);
        }
    }
    // The following will then go through your results and print them to the console to     
    // demonstrate how to access the dictionary
    Console.WriteLine("Results:");
    foreach(KeyValuePair<string, string> pair in pe.Responses)
    {
        Console.WriteLine($"{pair.Key}: {pair.Value}");
    }
}
...
class PotentialEmployee
{
    // Add a dictionary to your object properties
    public Dictionary<string, string> Responses { get; set; }
    ...
    public PotentialEmployee()
    {
        // Make sure you initialize the Dictionary in the Constructor
        Responses = new Dictionary<string, string>();
    }
    ...
}
