    public static void Main(string[] args)
    {
        Task t = SubmitFlightReportAsync("bla");
        t.Wait(); //This is the line you need to have when working with console apps.
    }
