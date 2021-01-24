    var fileLines = File.ReadAllLines(stylistFilePath);
    var stylists = new List<Stylist>();
    for (int i = 0; i < fileLines.Length; i += 6)
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
