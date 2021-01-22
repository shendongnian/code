            for (int i = 1; i < pQuestionSpec.NumberOfLines; i++)
            {
                Table innerT = new Table();
                var col1 = new TableColumn();
                col1.Width = new GridLength(1, GridUnitType.Star);
                innerT.Columns.Add(col1);
                var innerRowGroup = new TableRowGroup();
                var innerRow = new TableRow();
                var cell2 = new TableCell();
                cell2.BorderThickness = new Thickness(0, 0, 0, 1);
                cell2.BorderBrush = Brushes.Black;
                cell2.Blocks.Add(new Paragraph());
                innerRow.Cells.Add(cell2);
                innerRowGroup.Rows.Add(innerRow);
                innerT.RowGroups.Add(innerRowGroup);
                cell.Blocks.Add(innerT);
            }
