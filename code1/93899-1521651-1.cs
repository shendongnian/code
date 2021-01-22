[STAThread]
static void Main(string[] args)
{
    if (args.Length == 0)
    {
        // Run the application in a windows form
        Application.Run(new MainForm( ));
    }
    else
    {
        // Run app from CLI
        Console.WriteLine(DoStuff(args));
    }
}
