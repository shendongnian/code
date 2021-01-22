            // dictionary we use to check for collisions
            Dictionary<MyHash, bool> checkForDuplicatesDic = new Dictionary<MyHash, bool>();
            // used to generate random arrays
            Random rand = new Random();
            var now = DateTime.Now;
            for (var j = 0; j < 100; j++)
            {
                for (var i = 0; i < 5000; i++)
                {
                    // create new array and populate it with random bytes
                    byte[] randBytes = new byte[byte.MaxValue];
                    rand.NextBytes(randBytes);
                    MyHash h = new MyHash(randBytes);
                    if (checkForDuplicatesDic.ContainsKey(h))
                    {
                        Console.WriteLine("Duplicate");
                    }
                    else
                    {
                        checkForDuplicatesDic[h] = true;
                    }
                }
                Console.WriteLine(j);
                checkForDuplicatesDic.Clear(); // clear dictionary every 5000 iterations
            }
            var elapsed = DateTime.Now - now;
            Console.Read();
