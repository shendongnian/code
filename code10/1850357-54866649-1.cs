    var outputstring = new List<string> { "Hello", "World" };
    var cofgravX = new List<int> { 5, 20 };
    var cofgravY = new List<int> { 5, 20 };
    // As for loop
    for (int i = 0; i < outputstring.Count; i++)
    {
        var message = outputstring[i];
        var fx = cofgravX[i]; // This could throw an ArgumentOutOfRangeException
        var fy = cofgravY[i]; // This could throw an ArgumentOutOfRangeException
        // ToDo: Draw on graphics object
    }
    // LINQish way
    var items = cofgravX
        .Zip(cofgravY, (X, Y) => new { X, Y })
        .Zip(outputstring, (Position, Message) => new { Position, Message });
    // This will iterate as long as the shortest sequence of all three collection.
    foreach (var item in items)
    {
        var message = item.Message;
        var fx = item.Position.X;
        var fy = item.Position.Y;
        // ToDo: Draw on graphics object
    }
