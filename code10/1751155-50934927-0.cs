    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "User ID=postgres;Password=pass;Host=localhost;Port=5432;Database=TestUser;";
            var connection = new NpgsqlConnection(connectionString);
            var _login = "someLogin";
            var _passwd = "somePass";
            connection.Open();
            var result = connection.Query<User>("select * from public.users where login=@login and password=@passwd", new { login = _login, passwd = _passwd });
            connection.Close();
            foreach (var item in result)
            {
                Console.WriteLine($"Id: {item.Id}. Login: {item.Login}");
            }
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
