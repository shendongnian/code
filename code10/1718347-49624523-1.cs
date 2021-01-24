    using (var writer = new StreamWriter(outputFile)) {
        foreach (var line in File.ReadLines(filePath)) {                    
            var tmp = line.Trim(); // remove trailing whitespace
            bool hadTrailingComma = tmp.EndsWith(",");
            tmp = tmp.Remove(tmp.Length - 2, 2); // remove closing ) and , or ;
            tmp = tmp.Remove(0, 1); // remove opening (                                                            
            var words = Regex.Split(tmp, @",(?=(?:[^\']*\'[^\']*\')*[^\']*$)");
            var newLine = String.Join(",", words.Select((w, i) =>
            {
                w = w.Trim();
                var targetSize = sizes[i];
                if (w.Length < targetSize)
                    return w + new string(' ', targetSize - w.Length); // append spaces until max length
                return w;
            }));
            
            writer.WriteLine($"({newLine}){(hadTrailingComma ? "," : ";")}");
        }
    }
