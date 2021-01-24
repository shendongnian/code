    if (line == "Y") {
        for (int i = 0; i < 5; i++) {
            writer.WriteLine(i.ToString());
            writer.Flush();
            // simulate delay
            Thread.Sleep(100);
        }
        // empty line
        writer.WriteLine();
        writer.Flush();
    }
