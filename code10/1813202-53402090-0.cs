    public static class PaddedColumns
    {
        private static string[][] _stringArray = new string[][] {
            new [] {"Name:", "John", "Jones."},
            new [] {"Date of birth:", "Monday,", "07/11/1989."},
            new [] {"Age:", "29", "Years old."},
            new [] {"Eye Color:", "blue", ""},
        };
        public static void PadIt()
        {
            OutputPadded(_stringArray);
        }
        public static void OutputPadded(string[][] strings)
        {
            var columnMaxes = new int[strings[0].Length];
            foreach (var row in strings)
            {
                for (var colNo = 0; colNo < row.Length; ++colNo)
                {
                    if (row[colNo].Length > columnMaxes[colNo])
                    {
                        columnMaxes[colNo] = row[colNo].Length;
                    }
                }
            }
            const int extraPadding = 2;
            //got the maxes, now go through and use them to pad things
            foreach (var row in strings)
            {
                for (var colNo = 0; colNo < row.Length; ++colNo)
                {
                    Console.Write(row[colNo].PadRight(columnMaxes[colNo] + extraPadding));
                }
                Console.WriteLine("");
            }
        }
    }
