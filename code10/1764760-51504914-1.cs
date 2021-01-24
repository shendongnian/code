            // don't format upper leftmost cell
            // don't try to format a null or blank cell
            // don't try to format unless it's a valid number
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Value == null || e.Value == DBNull.Value || 
                String.IsNullOrWhiteSpace(e.Value.ToString()) || !e.Value.ToString().All(char.IsDigit))
            {
                return;
            }
