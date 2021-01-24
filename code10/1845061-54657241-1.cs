     private static void Main(string[] args)
        {
            const int calsBurnedPerMinute = 5;
            // i represents minutes between 1 and 45
            for (var i = 1; i <= 45; i++)
            {
                var calsBurned = 0;
                switch (i)
                {
                    case 20:
                        calsBurned = calsBurnedPerMinute * i;
                        Console.WriteLine("Calories Burned After 20 minutes: " + calsBurned);
                        break;
                    case 35:
                        calsBurned = calsBurnedPerMinute * i;
                        Console.WriteLine("Calories Burned After 35 minutes: " + calsBurned);
                        break;
                    case 45:
                        calsBurned = calsBurnedPerMinute * i;
                        Console.WriteLine("Calories Burned After 45 minutes: " + calsBurned);
                        break;
                }
            }
            Console.ReadKey();
        }
