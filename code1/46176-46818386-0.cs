            DgDbNames.Columns.Add(new DataGridTextColumn()
            {
                Header = "Db Name",
                Binding = new System.Windows.Data.Binding("DbName"),
                IsReadOnly = true,
                Width = new DataGridLength(0.2, DataGridLengthUnitType.Star),
                CellStyle = new Style(typeof(DataGridCell))
                {
                    Setters = {
                        new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center)
                    }
                }
            });
