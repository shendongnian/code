    public static void Main(string[] args)
        {
            var collection = new List<IScreen>()
            {
                new Screen
                {
                    Fields = new AnotherCustomCollection<ScreenInterface.IBaseField>
                    {
                        new TextField()
                        {
                            Name = "Hello"
                        }
                    }
                }
            };
            var y = collection.First();
            //Prints "Hello"
            Console.WriteLine(string.Join(" ", y.Fields.Select(x => x.Name)));
            Console.ReadLine();
        }
