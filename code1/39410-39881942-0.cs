        private static void RunTakeSkipExample()
        {
            int takeSize = 10; /* set takeSize to 10 */
            /* create 25 exceptions, so 25 / 10 .. means 3 "takes" with sizes of 10, 10 and 5 */
            ICollection<ArithmeticException> allArithExceptions = new List<ArithmeticException>();
            for (int i = 1; i <= 25; i++)
            {
                allArithExceptions.Add(new ArithmeticException(Convert.ToString(i)));
            }
            int counter = 0;
            IEnumerable<ArithmeticException> currentTakeArithExceptions = allArithExceptions.Skip(0).Take(takeSize);
            while (currentTakeArithExceptions.Any())
            {
                Console.WriteLine("Taking!  TakeSize={0}. Counter={1}. Count={2}.", takeSize, (counter + 1), currentTakeArithExceptions.Count());
                foreach (ArithmeticException ae in currentTakeArithExceptions)
                {
                    Console.WriteLine(ae.Message);
                }
                currentTakeArithExceptions = allArithExceptions.Skip(++counter * takeSize).Take(takeSize);
            }
        }
