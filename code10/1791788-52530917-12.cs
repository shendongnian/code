    class Program
    {
        static void Main(string[] args)
        {
            var userList = Utility.JsonParser<User>("You json either object or array");
            if (userList.Count > 0)
            {
                userList.ForEach(user => Console.WriteLine($"Id: {user.Id},  Name: {user.Name}, Age: {user.Age}"));
            }
            else
            {
                //Do code here if your list is empty
            }
            Console.ReadLine();
        }
    }
    
