    static class Program
    {
        public static void Main(string[] args)
        {
            //Sample json i get in variable
            var json = @"[{'user_id':'ho896ty6','user_name':'Mikje Flanders','age':43},{'user_id':'ft357hj','user_name':'Anna Simpson','age':56}]";
            //This line convert your string json to c# object
            List<User> userList = JsonConvert.DeserializeObject<List<User>>(json);
            //Loop through to get each object inside users list
            foreach (User user in userList)
            {
                Console.WriteLine($"user_id: {user.user_id},  user_name: {user.user_name}, age: {user.age}");
            }
    
            Console.ReadLine();
        }
    }
    
