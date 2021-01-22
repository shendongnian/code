    var output = FindAllDerivedTypes<System.IO.Stream>();
                foreach (var type in output)
                {
                    Console.WriteLine(type.Name);
                }
