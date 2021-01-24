    class Program
    {
        static void Main(string[] args)
        {
            Sample sample = JsonConvert.DeserializeObject<Sample>(resp.Body);
            foreach (var item in sample.Data)
            {
                Console.WriteLine(item.Key);
                Userr user = item.Value.ToObject<Userr>();
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
    
