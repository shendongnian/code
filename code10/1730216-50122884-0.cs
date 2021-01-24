Your best bet is to do a FirstOrDefault and then check if that is null/empty/etc as if it were your bool. Though this is a very basic example it should get the point across. What you do with that result and if it should just be one or more, etc is up to your circumstances.
        static void Main()
        {
            string test = "foo+";
            string[] operators = { "+", "-", "*", "/" };
            bool result = operators.Any(x => test.EndsWith(x));
            string actualResult = operators.FirstOrDefault(x => test.EndsWith(x));
            
            if (result)
            {
                Console.WriteLine("Yay!");
            }
            if (!string.IsNullOrWhiteSpace(actualResult))
            {
                Console.WriteLine("Also Yay!");
            }
        }
