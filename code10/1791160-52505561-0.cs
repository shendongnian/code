            const string EX = "X";
            const string OU = "O";
            const int VALUE_X = 8;
            bool writeToggle = true;
            int numRows = 0;
            int numCol = 0;
            for (numRows = 0; numRows < VALUE_X; numRows++)
            {
                for (numCol = 0; numCol < VALUE_X; numCol++)
                {
                    if (writeToggle)
                    {
                        Console.Write(EX);
                    }
                    else
                    {
                        Console.Write(OU);
                    }
                    writeToggle = !writeToggle;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
