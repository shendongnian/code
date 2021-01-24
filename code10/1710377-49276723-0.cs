    var array=Enumerable.Range(1,25).ToArray();
    for (int row = 0; row  < 5; row ++)
        {
            for (int column = 0; column  < 5; column  ++)
            {
                Console.WriteLine("Value in column {0}, row {1} is {2}", column, row, array.getEntry(column,row));
            }
        }
