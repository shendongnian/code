    var line = reader.ReadLine();
    if (line == "Y") {
        for (int i = 0; i < 5; i++) {
            writer.WriteLine(i.ToString());
            writer.Flush();
            // delay
            Thread.Sleep(100);
        }
    }
