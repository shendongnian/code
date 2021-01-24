    reader.ReadToDescendant("Section");
    do
    {
        Console.WriteLine("Section");
        using (var innerReader = reader.ReadSubtree())
        {
            while (innerReader.ReadToFollowing("Field"))
            {
                Console.WriteLine("field");
            }
        }
    } while (reader.ReadToNextSibling("Section"));
