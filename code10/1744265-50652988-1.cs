      static void Main(string[] args)
            {
                ClassA A = new ClassA()
                {
                    ClassB = new ClassB()
                    {
                        Name = "NameClassB"
                    }
                };
    
                string json = JsonConvert.SerializeObject(A);
                var obj = JObject.Parse(json);
    
                var name = obj.SelectToken("$.ClassB.Name");
    
                System.Console.WriteLine(name); 
               // output --> NameClassB    
    
            }
        }
    
        class ClassA
        {
            public ClassB ClassB { get; set; }
        }
    
        class ClassB
        {
            public string Name { get; set; }
        }
