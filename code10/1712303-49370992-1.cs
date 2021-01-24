        static void FillCard(string[,] table)
        {
            var BValues = Enumerable.Range(1, 15).ToList();
            var IValues = Enumerable.Range(16, 15).ToList();
            var NValues = Enumerable.Range(31, 15).ToList();
            var GValues = Enumerable.Range(46, 15).ToList();
            var OValues = Enumerable.Range(61, 15).ToList();
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    switch (col)
                    {
                        case 0: // B
                            table[row, col] = GetRandomItemAndRemoveIt(BValues);
                            break;
                        case 1: // I
                            table[row, col] = GetRandomItemAndRemoveIt(IValues);
                            break;
                        case 2: // N
                            table[row, col] = GetRandomItemAndRemoveIt(NValues);
                            break;
                        case 3: // G
                            table[row, col] = GetRandomItemAndRemoveIt(GValues);
                            break;
                        case 4: // O
                            table[row, col] = GetRandomItemAndRemoveIt(OValues);
                            break;
                    }
                }
            }
        }
