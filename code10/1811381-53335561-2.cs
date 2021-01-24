        static void Main(string[] args)
        {
            Random rand = new Random();
            int minA, maxA;
            int minB, maxB;
            int userAnswer;
            Console.WriteLine("what is the minimum A: ");
            if (!Int32.TryParse(Console.ReadLine(), out minA)) { return; } //If something going wrong, you should handle it.
            Console.WriteLine("what is the maximum A: ");
            if (!Int32.TryParse(Console.ReadLine(), out maxA)) { return; }
            Console.WriteLine("what is the minimum B: ");
            if (!Int32.TryParse(Console.ReadLine(), out minB)) { return; }
            Console.WriteLine("what is the maximum B: ");
            if (!Int32.TryParse(Console.ReadLine(), out maxB)) { return; }
            if (minA > maxA) { exchange(ref minA, ref maxA); } //User might have typo,and this is one way to fix it.
            if (minB > maxB) { exchange(ref minB, ref maxB); }
            int rndA = rand.Next(minA, maxA),
                rndB = rand.Next(minB, maxB); //You should restore the random result, or lost it
            int result;
            try
            {
                result = calcMod(rndA, rndB); //Directly implementing the random numbers generated with modulous operator
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
            Console.WriteLine($"What is the result of {rndA} % {rndB}? ");
            Int32.TryParse(Console.ReadLine(), out userAnswer);
            if (userAnswer == result)
            {
                Console.WriteLine("{0} is correct", result);
            }
            else
            {
                Console.WriteLine($"Good try, but no: {rndA} % {rndB} = {result}");
            }
            Console.Write("\nPress Any key to leave.");
            Console.ReadKey();
        }
        //Calculate mod result
        static int calcMod(int i1, int i2)
        {
            try
            {
                return i1 % i2;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Swap number
        static void exchange(ref int i1, ref int i2)
        {
            int tmp;
            tmp = i1;
            i1 = i2;
            i2 = tmp;
        }
