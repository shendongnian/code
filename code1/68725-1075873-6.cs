    //context has to be moved outside the function
    static ExampleDataContext context = new ExampleDataContext();
    //Here we can return an IEnumerable of Election now, instead of using the Tuple class
    public static IEnumerable<Election> getElections()
    {
        return from election in context.Elections
               select election;
    }
    static void Main(string[] args)
    {
        //get the elections
        var elections = getElections();
        //lets go through the elections
        foreach (var election in elections)
        {
            //here we can access election status via the ElectionStatus property
            Console.WriteLine("Election name: {0}; Election status: {1}", election.ElectionName, election.ElectionStatus.StatusDescription);
        }
    }
