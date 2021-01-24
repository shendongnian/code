    class Program
    {
        static void Main(string[] args)
        {
            var result = Utility.JsonParser<User>("You json either object or array");
    
            if (result is List<User>)
            {
                var userList = result as List<User>;
                userList.ForEach(user => Console.WriteLine($"Id: {user.Id},  Name: {user.Name}, Age: {user.Age}"));
            }
            else if (result is User)
            {
                var user = result as User;
                Console.WriteLine($"Id: {user.Id},  Name: {user.Name}, Age: {user.Age}");
            }
            else if (result is string)
            {
                Console.WriteLine(result);
            }
    
            Console.ReadLine();
        }
    }
