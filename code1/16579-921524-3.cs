    PositionableStreamReader sr = new PositionableStreamReader("somepath.txt");
    // read some lines
    while (something)
        sr.ReadLine();
    // bookmark the current position
    long streamPosition = sr.Position;
    // read some lines
    while (something)
        sr.ReadLine();
    // go back to the bookmarked position
    sr.Position = streamPosition;
    // read some lines
    while (something)
        sr.ReadLine();
