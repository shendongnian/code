    string f = "Common - check - 01[1080p].mp4";
    // If you need the individual parts...
    string[] parts = f.Split('-');
    string newName = string.Join("-", parts.Take(parts.Length - 1));
    Console.WriteLine(newName);
    
    // If you don't...
    newName = f.Substring(0, f.LastIndexOf('-'));
    Console.WriteLine(newName);
