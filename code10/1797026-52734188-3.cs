    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ 'token_type':'Bearer','access_token':'12345678910','user':{ 
                                           'id':123456,'username':'jbloggs','resource':2,'firstname':'joe'}
                                         }";
            Token token = JsonConvert.DeserializeObject<Token>(json);
            Console.WriteLine("token_type: " + token.token_type);
            Console.WriteLine("access_token: " + token.access_token);
            Console.WriteLine();
            Console.WriteLine("id: " + token.user.id);
            Console.WriteLine("username: " + token.user.username);
            Console.WriteLine("resource: " + token.user.resource);
            Console.WriteLine("firstname: " + token.user.firstname);
            Console.ReadLine();
        }
    }
