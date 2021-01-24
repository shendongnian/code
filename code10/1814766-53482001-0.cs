    public DatabaseHelper(IConfiguration Configuration)
    {
       string test = Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
       Console.WriteLine(test);
    }
