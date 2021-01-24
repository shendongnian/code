    private const int SleepMillis = 5;
    private const int MaxRetries = 3;
    
    public void WriteFile(string fileName, string[] fileLines, int retries = 0)
    {
        try
        {
            File.WriteAllLines(fileName, fileLines);
        }
        catch(Exception e) //Catch the special type if you can
        {
            if (retries >= MaxRetries)
            {
                Console.WriteLine("Too many tries with no success");
                throw; // rethrow exception
            }
            Thread.Sleep(SleepMillis);
            WriteFile(fileName, fileLines, ++retries); // try again
        }
    }
