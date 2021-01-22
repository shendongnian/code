    static class Program {
        static void Main() {
            var data = new[] {
                new { Foo = 1,Bar = "a"}, new { Foo = 2,Bar = "b"}, new {Foo = 1, Bar = "c"}
            };
            foreach (var item in data.DistinctBy(x => x.Foo))
                Console.WriteLine(item.Bar);
            }
        }
    }
