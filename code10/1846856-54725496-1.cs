        class Value
        {
            public string CustomerAccount { get; set; }
            public string Name { get; set; }
        
        }
        
        class Customer
        {
            public List<Value> Value { get; set; }
            
        }
        class Program
        {
            static void Main(string[] args)
            {
                
              var obj =  JsonConvert.DeserializeObject<Customer>(@"     {
                '@odata.context': 'https://con813-crm612cf723bbf35af6devaos.cloudax.dynamics.com/data/$metadata#Customers(CustomerAccount,Name)',
                'value': [
                {
                    '@odata.etag': 'W/\'JzAsMjI1NjU0MjE1NTg7MCwwOzAsNTYzNzE0NTMyODswLDU2MzcxNDQ1NzY7MCwyMjU2NTQyNTY5MzswLDIyNTY1NDI3MjM2OzAsMDswLDIyNTY1NDI3MjM2OzAsMjI1NjU0MjcyMzY7MCwwJw==\'',
                    'CustomerAccount': 'DE-001',
                    'Name': 'Contoso Europe'
                },
                {
                    '@odata.etag': 'W/\'JzAsMjI1NjU0MjE1NTk7MCwwOzAsMzU2MzcxNDkxMTI7MCw1NjM3MTQ0NTc3OzAsMjI1NjU0MjU2OTQ7MCwyMjU2NTQyNzIzODswLDA7MCwyMjU2NTQyNzIzODswLDIyNTY1NDI3MjM4OzAsMCc=\'',
                    'CustomerAccount': 'US-001',
                    'Name': 'Contoso Retail San Diego'
                },
                {
                    '@odata.etag': 'W/\'JzAsMjI1NjU0MjE1NjA7MCwwOzAsMzU2MzcxNDkxMTM7MCw1NjM3MTQ0NTc4OzAsMjI1NjU0MjU2OTU7MCwyMjU2NTQyNzI0MDswLDA7MCwyMjU2NTQyNzI0MDswLDIyNTY1NDI3MjQwOzAsMCc=\'',
                    'CustomerAccount': 'US-002',
                    'Name': 'Contoso Retail Los Angeles'
                }
                ]
                }");
                
                foreach (var value in obj.Value)
                {
                    Console.WriteLine($"Name: 'Name' Value: {value.Name}");
                    Console.WriteLine($"Name: 'CustomerAccount' Value: {value.CustomerAccount}");
                }
    
            }
        }
