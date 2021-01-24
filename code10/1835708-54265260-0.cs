    static void Main(string[] args)
    {
        var command = new SqlCommand("People_Insert");
        command.CommandType = CommandType.StoredProcedure;
        var idParam = command.Parameters.Add("@Id", SqlDbType.Int, 5);
        idParam.Direction = ParameterDirection.Output;
        
        var titleParam = command.Parameters.Add("@Title", SqlDbType.NVarChar, 100);
        var bioParam = command.Parameters.Add("@Bio", SqlDbType.NVarChar, 100);
        var summaryParam = command.Parameters.Add("@Summary", SqlDbType.NVarChar, 100);
        var headlineParam = command.Parameters.Add("@Headline", SqlDbType.NVarChar, 100);
        var slugParam = command.Parameters.Add("@Slug", SqlDbType.NVarChar, 100);
        var statusIdParam = command.Parameters.Add("@StatusId", SqlDbType.Int, 3);
        var skillsParam = command.Parameters.Add("@Skills", SqlDbType.NVarChar, 100);
        var primaryImageParam = command.Parameters.Add("@PrimaryImage", SqlDbType.NVarChar, 100);
        Console.WriteLine("Please Enter a Title");
        titleParam.Value = Console.ReadLine();
        Console.WriteLine("Please Enter a Bio");
        bioParam.Value = Console.ReadLine();
        Console.WriteLine("Please Enter a Summary");
        summaryParam.Value = Console.ReadLine();
        Console.WriteLine("Please Enter a Headline");
        headlineParam.Value = Console.ReadLine();
        Console.WriteLine("Please Enter a Unique Slug");
        slugParam.Value = Console.ReadLine();
        Console.WriteLine("Please Enter a 1 digit Status Id");
        statusIdParam.Value = Console.Read();
        Console.WriteLine("Please Enter Skills");
        skillsParam.Value = Console.ReadLine();
        Console.WriteLine("Enter an Image Url");
        primaryImageParam.Value = Console.ReadLine();
        using (var connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=PeopleDatabase;Trusted_Connection=True;"))
        {
            connection.Open();
            command.Connection = connection;
            var affectedRowsCount = command.ExecuteNonQuery();
            Console.WriteLine("Number of Rows: " + affectedRowsCount);
            Console.WriteLine("Return Value: " + idParam.Value);
        }
        Console.ReadLine();
    }
