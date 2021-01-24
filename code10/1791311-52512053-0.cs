    var result = Console.ReadLine()
                        .Split(' ')
                        .Select(input => 
                        {
                            int? output = null;
                            if(int.TryParse(input, var out parsed))
                            {
                                output = parsed;
                            }
                            return output;
                        })
                        .Where(x => x != null)
                        .ToArray();
