      public List<string> LoadStringList()
        {
            List<string> stringList = new List<string>();
    
            if (contactDataGridView.RowCount != 0)
            {
                for (int i = 0; i < contactDataGridView.Rows.Count; i++)
                {
                    var stringData = contactDataGridView.Rows[i].Cells[2].Value as string;
                    if(!string.IsNullOrEmpty(stringData))
                    {
                        stringList.Add(stringData);
                    }
                }
    
            }
            return stringList;
        }
