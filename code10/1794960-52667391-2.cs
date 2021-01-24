        static void Main(string[] args)
        {
            var foo = new Foo { Name = "parent foo" };
            var foo1 = new Foo { Name = "first foo child" };
            var foo2 = new Foo { Name = "second foo child" };
            foo.Children.Add(foo1);
            foo.Children.Add(foo2);
            using(var context = new MyContext())
            {
                context.Foos.Add(foo);
                context.SaveChanges();
            }
            // another transaction to read the saved data
            using(var context = new MyContext())
            {
                var readfoo = context.Foos.FirstOrDefault();
                Console.WriteLine($"{readfoo.Name} has the following children:");
                foreach(var child in readfoo.Children)
                    Console.WriteLine(child.Name);
            }
            Console.ReadKey();
        }
