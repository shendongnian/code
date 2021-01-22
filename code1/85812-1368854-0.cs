    System.IO.File.WriteAllLines(
        "outfilename.txt",
        System.IO.File.ReadAllLines("infilename.txt").Select(line =>
            "{" +
            string.Join(", ",
                line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            ) + "}"
        ).ToArray()
    );
