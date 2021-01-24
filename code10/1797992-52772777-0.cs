            char[] input = { 'h', 'e', 'l', 'l', 'o' };
            char[] inputnew = new char[input.Length];
            Array.Copy(input, inputnew, input.Length);
            Array.Reverse(inputnew);
            Console.WriteLine(new string(input));
            Console.WriteLine(new string(inputnew));
