    class Program
    {
        static void Main(string[] args)
        {
            var name = "Bob";
            var newAccount = new Account();
            newAccount.AccountName = name;
            Console.WriteLine(name);
            Console.WriteLine(newAccount.AccountName);
        }
    }
    public class Account
    {
        public string AccountName { get; set; }
    }
