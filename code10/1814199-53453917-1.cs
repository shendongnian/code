     IDictionary<string, object> ColumnHeaderDictionary = new Dictionary<string, object>(); 
            foreach (string columnheader in PossibleColumnList)
            {
                if (ColumnHeaderDictionary.ContainsKey(columnheader) == false) ColumnHeaderDictionary.Add(columnheader, new object());
            }
