            string[] arrayCart = { "Apple", "Orange", "Grape", "Orange", "Corn", "Apple", "Grape", "Apple", "Orange", "Orange" };
            Dictionary<int, string> options = new Dictionary<int, string>
            {
                [1] = "Apple",
                [2] = "Orange",
                [3] = "Grape",
                [4] = "Corn",
            };
            Console.WriteLine("\r\nChoose and item:");
            foreach (var option in options)
            {
                Console.WriteLine($"\r\n[{option.Key}] - {option.Value}");
            }
            int cartItem = Convert.ToInt32(Console.ReadLine());
            if (options.TryGetValue(cartItem, out var insertedOption))
            {
                var count = arrayCart.Count(x => string.Equals(x, insertedOption));
                Console.WriteLine($"In the shopping cart there are {count} {insertedOption}");
            }
            else
            {
                Console.WriteLine("Given option doesn't exist");
            }
