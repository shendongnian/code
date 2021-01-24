    var allLines = File.ReadAllLines(originalFile);
    var headerLine = allLines.First();
    var dataLines = allLines.Skip(1);
    var processedLines = ProcessLines(dataLines);
    File.WriteAllLines(newFile, (new[] {headerLine}.Concat(processedLines)).ToArray());
