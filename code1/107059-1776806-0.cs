    StackTrace st = new StackTrace();
    foreach (var frame in st.GetFrames())
    {
        Console.WriteLine(frame.GetFileName().ToString()
            + ":"
            + frame.GetFileLineNumber().ToString());
    }
