     Console.WriteLine(
        yourCollection.Select(s => new
                        {
                            column1 = s.col1,
                            column2 = s.col2,
                            column3 = s.col3,
                            StaticColumn = "X"
                        })
                        .ToMarkdownTable());
