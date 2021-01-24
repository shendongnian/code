    using (var reader = OpenXmlReader.Create(worksheetPart))
    {
        while (reader.Read())
        {
            if (typeof(Row).IsAssignableFrom(reader.ElementType))
            {
                var row = (Row)reader.LoadCurrentElement();
                foreach (var cell in row.Elements<Cell>())
                {
                    var (_, value) = ParseCell(cell);
                }
            }
        }
    }
