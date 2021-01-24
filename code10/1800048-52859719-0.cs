            bool success = false;
            do
            {
                Console.WriteLine("enter number");
                var n = Console.ReadLine();
                if (n == null)
                {
                    // goto Enter_No;
                }
                else
                {
                    int typedNum;
                    success = int.TryParse(n, out typedNum);
                    Console.WriteLine(typedNum);                    
                }
            } while (!success);
