      Uri u = new Uri("http://localhost:31404/Api/Customers");
            var payload = "{\"CustomerId\": 5,\"CustomerName\": \"Pepsi\"}";
    
            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, c));
            t.Wait();
    
            Console.WriteLine(t.Result);
            Console.ReadLine();
