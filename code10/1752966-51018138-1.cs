    Console.WriteLine(RowColumn("Hello\r\nWorld", 0)); // (1, 1)
    Console.WriteLine(RowColumn("Hello\r\nWorld", 4)); // (1, 5)
    Console.WriteLine(RowColumn("Hello\r\nWorld", 7)); // (2, 1)
    Console.WriteLine(RowColumn("Hello\r\nWorld", 11)); // (2, 5)
    Console.WriteLine(RowColumn("Hello\nWorld", 0)); // (1, 1)
    Console.WriteLine(RowColumn("Hello\nWorld", 4)); // (1, 5)
    Console.WriteLine(RowColumn("Hello\nWorld", 6)); // (2, 1)
    Console.WriteLine(RowColumn("Hello\nWorld", 10)); // (2, 5)
    Console.WriteLine(RowColumn("Hello\rWorld", 0)); // (1, 1)
    Console.WriteLine(RowColumn("Hello\rWorld", 4)); // (1, 5)
    Console.WriteLine(RowColumn("Hello\rWorld", 6)); // (2, 1)
    Console.WriteLine(RowColumn("Hello\rWorld", 10)); // (2, 5)
    var rc = RowColumn("Hello\rWorld", 10);
    int row = rc.row;
    int col = rc.col;
