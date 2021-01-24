    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection c = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=tempdb;Data Source=.\SQLEXPRESS");
            c.Execute(@"
    CREATE PROCEDURE GetPerson(
        @N VARCHAR(10),
        @A INT,
        @S INT
    )AS
    BEGIN
        SELECT @N as Name, @A as Age, @S as Salary;
    END;");
            //works
            var p = c.Query<Person>("GetPerson", new { A = 1, N = "John", S = 1000 }, commandType: System.Data.CommandType.StoredProcedure);
            //doesn't work, "procedure expects parameter @A which was not supplied"
            int i = 2, j = 2000; string n = "Frank";
            var q = c.Query<Person>("GetPerson", new { i, n, j }, commandType: System.Data.CommandType.StoredProcedure);
            //works
            int A = 3, S = 3000; string N = "Joe";
            var r = c.Query<Person>("GetPerson", new { S, A, N }, commandType: System.Data.CommandType.StoredProcedure);
            //works
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@A", 4);
            dp.Add("@N", "Derek");
            dp.Add("@S", 4000);
            var s = c.Query<Person>("GetPerson", dp, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
