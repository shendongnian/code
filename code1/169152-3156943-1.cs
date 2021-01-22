    public static void Main()
    {
        LoadCorrectDLLs();
        // This line would force DotNetZip to get loaded before Main() is called
        IDotNetZipInterface x = null;
    }
