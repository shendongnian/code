    ...
    if (!ctx.Languages.Any(l => l.ID == 1))  // Check if already on file
    {
        ctx.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Language ON");  // Omit if not identity column
        var dutch = new Language {
            ID = 1,
            Name = "Dutch",
            Code = "NL"
        };
        ctx.Languages.Add(dutch);
        ctx.SaveChanges();
        ctx.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Language OFF"); // Omit if not identity column
    }
    ... repeat for other languages
    ... similar code for other seeded tables
