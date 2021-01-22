    void ReadTest()
    {
        // Read sample data from CSV file
        using (CsvFileReader reader = new CsvFileReader("ReadTest.csv"))
        {
            CsvRow row = new CsvRow();
            while (reader.ReadRow(row))
            {
                foreach (string s in row)
                {
                    Console.Write(s);
                    Console.Write(" ");
                }
                Console.WriteLine();
                row = new CsvRow(); //this line added
            }
        }
    }
