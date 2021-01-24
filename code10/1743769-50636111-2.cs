    static public int AskInt(string question)
    {
        int answer = 0;
        bool successfullyParsed = false;
        do
        {
            Console.Write(question);
            successfullyParsed = int.TryParse(Console.ReadLine(), out var parsedAnswer);
            Console.WriteLine("Only Numbers, dude");
            answer = parsedAnswer;
        } while (!successfullyParsed);
        return answer;
    }
