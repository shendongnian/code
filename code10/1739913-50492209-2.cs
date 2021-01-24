            // Declare a variable for writing the stars to the console:
            int numWritten;
            // Print the ascending number of stars
            while(numStars <= maxNumStars)
            {
                // Reset the number of stars written:
                numWritten = 0;
                // Write the stars with a loop:
                while (++numWritten <= numStars)
                    Console.Write("*");
                // End the line and increment the numStars variable:
                Console.WriteLine();
                numStars++;
            }
