    void addRows(string name, string value)
    {
        string teststring = name + "";
        int spacesAdded = 0;
        while (maxNameWidth > graphics.MeasureString(teststring + "x", measurementFont).Width)
        {
            spacesAdded++;
            teststring += " ";
        }
        Console.WriteLine(":" + name + " ".PadRight(spacesAdded) + ":" + value + ":" + spacesAdded);
    }
