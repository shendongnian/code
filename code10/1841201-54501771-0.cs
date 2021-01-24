        static void Main(string[] args)
        {
            PrintStars(8, 0, 0);
        }
        static void PrintStars(int stars, int prefix, int suffix)
        {
            if(stars == 1)
            {
                PrintStarsToConsole(stars, prefix, suffix);
                return;
            }
            var halfStars = stars >> 1;
            PrintStars(halfStars, prefix + halfStars, suffix); // for n = 4: __**
            PrintStarsToConsole(stars, prefix, suffix);        // for n = 4: ****
            PrintStars(halfStars, prefix, suffix + halfStars); // for n = 4: **__
        }
        static void PrintStarsToConsole(int stars, int prefix, int suffix)
        {
            Console.Write(new string(' ', prefix));
            Console.Write(new string('*', stars));
            Console.Write(new string(' ', suffix));
            Console.WriteLine();
        }
