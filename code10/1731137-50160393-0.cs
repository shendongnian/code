      void InputToDataGrid(IEnumerable<Records> records)
        {
            foreach (var record in records)
            {
                string listText = ""; //resets the text for each row in grid.
                foreach (var item in listVariableToBreak)
                {
                    listText += ", " +item.ToString();
                }
                dataGrid.Rows.Add(new[] {columnOne, columnTwo,..., listText});
            }
        }
