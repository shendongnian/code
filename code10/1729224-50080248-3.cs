      Dictionary<string, int> dict = file
        .AsParallel()                              // Doing in parallel
        .SelectMany(file => File.ReadLines(files)) // Read all lines of all files
        .SelectMany(line => line.Split(            // Split each line into words
           new char[] {' '}, 
           StringSplitOptions.RemoveEmptyEntries))
        .GroupBy(w => w) // Group by each word
        .ToDistionary(chunk => chunk.Key, chunk => chunk.Count()); 
