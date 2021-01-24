        static void Main(string[] args)
        {
            int numStars = 1;
            int maxNumStars = 5;
            // Print the ascending number of stars
            while(numStars <= maxNumStars)
            {
                // Write numStars number of stars to the console using the string constructor:
                Console.WriteLine(new string('*', numStars));
                numStars++;
            }
            // Print the descending number of stars
            while (numStars >= 1)
            {
                // Write numStars number of stars to the console using the string constructor:
                Console.WriteLine(new string('*', numStars));
                numStars--;
            }
        }
