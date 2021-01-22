      ...
        var column = new DataGridTextColumn()
        {
          Header = tbl.GetColumnName(i),
          Binding = new Binding
          {
            Converter = CellAccessConverter.Instance,
            Parameter = i
          }
        }
      ...
