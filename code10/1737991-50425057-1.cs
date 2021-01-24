            if (options.TryGetValue(cartItem, out var insertedOption))
            {
                int count = 0;
                foreach (var item in arrayCart)
                {
                    if (string.Equals(item, insertedOption))
                    {
                        count++;
                    }
                }
                Console.WriteLine($"In the shopping cart there are {count} {insertedOption}");
            }
            else
            {
                Console.WriteLine("Given option doesn't exist");
            }
