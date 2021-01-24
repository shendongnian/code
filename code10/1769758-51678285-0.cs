    private IEnumerable<string> GetDirFiles(string location)
    {
        IEnumerable<string> result;
        try
        {
            result = GetTextFiles(location).ToList(); //Added .ToList() to avoid multiple enumerations.
            if (!result.Any())
            {
              result = GetMsgFiles(location);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Message for admins: " + ex.Message);
        }
        finally
        {
            textBox1.Clear();
        }
        return result;
    }
    private IEnumerable<string> GetTextFiles(string location)
    {
        return Directory.EnumerateFiles(location, "*.txt", SearchOption.AllDirectories);
    }
    private IEnumerable<string> GetMsgFiles(string location)
    {
        return Directory.EnumerateFiles(location, "*.msg", SearchOption.AllDirectories);
    }
