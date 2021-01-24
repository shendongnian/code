    public static void Main(string[] args)
        {
            var collection = new List<ITable>() //here
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
            //Throws NotSupportedException
            Console.WriteLine(string.Join(" ", y.Fields.Select(x => x.Name)));
            Console.ReadLine();
        }
