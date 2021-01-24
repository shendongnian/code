            Random r = new Random(_seed);
            int seed = 1;
            Random r = new Random(seed);
            char[] _myChars = new char[170];
            for(var i = 0; i < _myChars.Length; i++)
            {
                _myChars[i] = (char)(i%26 + 65);
            }
            var output = _myChars.OrderBy(o => r.Next()).Take(13).ToList();
            for(var i = 0; i < output.Count; i++)
            {
                Console.WriteLine(output[i]);
            }
            Console.ReadLine();
