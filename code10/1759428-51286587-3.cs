    using Newtonsoft.Json;
    using System;
    
    namespace UsersJSON
    {
    
        public class UsersRepository
        {
            public User[] Users;
        }
    
        public class User
        {
            public int serialNo;
            public string[] details;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var json = @"{
      users: [
      {
        serialNo: 1,
        details: ['John', 'Receptionist']
      },
      {
        serialNo: 2,
        details: ['Alan', 'Salesman']
      }]
    }";
                var usersList = JsonConvert.DeserializeObject<UsersRepository>(json);
                Console.WriteLine(usersList.Users[0].details[0]); // prints "John"
                Console.ReadLine();
            }
        }
    }
