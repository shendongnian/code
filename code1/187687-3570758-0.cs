    static void Main(string[] args)
    {
        Console.WriteLine("Starting program execution...");
        string connectionString = @"Provider=VFPOLEDB.1;Data Source=C:\YourDirectory\";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand scriptCommand = connection.CreateCommand())
            {
                connection.Open();
                string vfpScript = @"Create Table TestDBF (Field1 I, Field2 C(10))
                                    USE TestDBF
                                    COPY TO OpensWithExcel TYPE Fox2x
                                    USE";
                scriptCommand.CommandType = CommandType.StoredProcedure;
                scriptCommand.CommandText = "ExecScript";
                scriptCommand.Parameters.Add("myScript", OleDbType.Char).Value = vfpScript;
                scriptCommand.ExecuteNonQuery();
            }
        }
        Console.WriteLine("End program execution...");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }
}
