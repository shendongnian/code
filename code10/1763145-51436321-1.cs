                static void Main(string[] args)
                {           
                NumberFormatInfo nfi = new CultureInfo("en-US").NumberFormat;
                // Displays a value with the default separator (".").
                Int64 myInt = 123456789012345;
                Console.WriteLine(myInt.ToString("N", nfi));
                // Displays the same value with different groupings.
                int[] mySizes1 = { 2, 3, 4 };
                int[] mySizes2 = { 2, 2 };
                nfi.NumberGroupSizes = mySizes1;
                Console.WriteLine(myInt.ToString("N", nfi));
                nfi.NumberGroupSizes = mySizes2;
                Console.WriteLine(myInt.ToString("N", nfi));
                ReadLine();
                }
