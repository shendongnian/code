     static void Main(string[] args)
            {
                var context = new ExpressionContext();
                const string exp = @"(Person.Age > 3 AND Person.Weight > 50) OR Person.Age < 3";
                context.Variables.DefineVariable("Person", typeof(Person));
                var e = context.CompileDynamic(exp);
    
                var bob = new Person
                {
                    Name = "Bob",
                    Age = 30,
                    Weight = 213,
                    FavouriteDay = new DateTime(2000, 1, 1)
                };
    
                context.Variables["Person"] = bob;
                var result = e.Evaluate();
                Console.WriteLine(result);
                Console.ReadKey();
            }
