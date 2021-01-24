    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DalSoft.RestClient;
    
    namespace ImTired
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    DoThingsAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                Console.ReadLine();
            }
    
            private static async Task<object> DoThingsAsync()
            {
                dynamic client = new RestClient("http://jsonplaceholder.typicode.com");
                List<User> users = await client.Users.Get();
                var foo = users[0].name; // grab the first item (Works to this point)
                
                var user = users[0]; 
                foreach (var propertyInfo in user.GetType().GetProperties())
                {
                    Console.WriteLine(propertyInfo.Name + " - " + propertyInfo.GetValue(user));
                }
                
                return null;
            }        
        }
        
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string website { get; set; }
        }
    }
 
