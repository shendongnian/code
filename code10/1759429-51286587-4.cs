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
            public UserDetails details;
        }
    
        public class UserDetails
        {
            public string name;
            public string job;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var json = @"{
      users: [
      {
        serialNo: 1,
        details: {name: 'John', job: 'Receptionist'}
      },
      {
        serialNo: 2,
        details: {name: 'Alan', job:'Salesman'}
      }]
    }";
                var usersList = JsonConvert.DeserializeObject<UsersRepository>(json);
                Console.WriteLine(usersList.Users[0].details.name); // prints "John"
                Console.ReadLine();
            }
        }
    }
