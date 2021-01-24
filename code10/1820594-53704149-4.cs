    class Program
    {
        static void Main(string[] args)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, User>>(resp.Body);
    
            foreach (var item in data)
            {
                User user = item.Value;
    
                Console.WriteLine("id: " + user.id);
                Console.WriteLine("imageURL: " + user.imageURL);
                Console.WriteLine("search: " + user.search);
                Console.WriteLine("status: " + user.status);
                Console.WriteLine("username: " + user.username);
                Console.WriteLine();
            }
    
            Console.ReadLine();
        }
    }
