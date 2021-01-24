    var result = Console.ReadLine()
                        .Split(' ')
                        .Select(input => 
                        {
                            int? output = null;
                            if(int.TryParse(input, out var parsed))
                            {
                                output = parsed;
                            }
                            return output;
                        })
                        .Where(x => x != null)
                        .Select(x=>x.Value)
                        .ToArray();
