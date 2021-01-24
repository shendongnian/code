    var fileLines = File.ReadAllLines(stylistFilePath)
        .Where(line => !string.IsNullOrEmpty(line))
        .ToList();
    var stylists = new List<Stylist>();
    // We have a condition to exit the loop if 'i + 4 < fileLines.Count'
    // because we access item [i + 4] inside the loop.
    for (int i = 0; i + 4 < fileLines.Count; i += 5)
    {
        stylists.Add(new Stylist
        {
            FirstName = fileLines[i],
            LastName = fileLines[i + 1],
            Email = fileLines[i + 2],
            Phone = fileLines[i + 3],
            Rate = fileLines[i + 4]
        });
    }
