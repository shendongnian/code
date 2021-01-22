    // EXAMPLE #2:
    // Sample for parsing the following command-line:
    // Test.exe /verbose /runId=10
    // This sample declares a class in which the strongly typed arguments are populated
    public class CommandLineArguments
    {
       bool? Verbose { get; set; }
       int? RunId { get; set; }
    }
    CommandLineArguments a = new CommandLineArguments();
    CommandLineParser.ParseArguments(args, a);
