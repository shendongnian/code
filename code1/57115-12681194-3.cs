c#
class Program
{
    static void Main(string[] args)
    {
        using (var spinner = new ConsoleSpiner())
        {
            spinner.Start();
            spinner.Message = "About to do some heavy staff :-)"
            DoWork();
            spinner.Message = "Now processing other staff".
            OtherWork();
            spinner.Stop();
        }
        Console.WriteLine("COMPLETED!!!!!\nPress any key to exit.");
    }
}
