    public static void Main()
    {
        try
        {
            TestMethod();
        }
        catch(Exception ex)
        {
            Console.Writeline(ex);
        }
    }
    private static void TestMethod()
    {
        if(..bad configuration)
            throw new ConfigurationException("configuration item");
        if(missing file)
            throw new FileMissingException("filename");
        // This method can throw Exception1 and Exception2
    }
    public class ConfigurationException : Exception {}
    public class FileMissingException : Exception {}
