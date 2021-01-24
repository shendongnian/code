    using System;
    namespace TestConsoleApplication
    {
        class Program
        {
            static double _totalLength, _totalWidth, _windowPerimeter, _glassArea;
            static void Main(string[] args)
            {
                DisplayInstructions();
                _totalWidth = AskDimension("Height");
                _totalLength = AskDimension("Width");
                _windowPerimeter = (2 * _totalWidth) + (2 * _totalLength);
                _glassArea = _totalWidth * _totalLength;
                Console.WriteLine("The length of the wood is " + _windowPerimeter + " feet");
                Console.WriteLine("The area of the glass is " + _glassArea + " square feet");
                Console.ReadKey();
            }
            private static void DisplayInstructions()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("This app will help you calculate the amount of wood and glass needed for your new windows!");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*Note* Please enter a height/width value between 0.01 - 100, all other values will cause a system error.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            private static double AskDimension(string dimensionType)
            {
                const double maxDimension = 100.0;
                const double minDimension = 0.01;
                Console.WriteLine($"Please enter your {dimensionType} of the window");
                var dimensionString = Console.ReadLine();
                var dimension = double.Parse(dimensionString);
                if (dimension < minDimension)
                {
                    DisplayDimensionErrorAndExit("Min");
                }
                else if (dimension > maxDimension)
                {
                    DisplayDimensionErrorAndExit("Max");
                }
                return dimension;
            }
            private static void DisplayDimensionErrorAndExit(string dimensionToShow)
            {
                Console.WriteLine($"You entered a value less than {dimensionToShow} dimension");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
