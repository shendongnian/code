        // Check if datarow is empty
        // dt = Datatable to be checked
        // index = index of the row that will be checked
        public bool isRowEmpty(DataTable dt, int index)
        {
            // check if index exists, if not returns false
            // it will means that the row is "not empty"
            if (index >= dt.Rows.Count || index < 0)
                return false;
            // Get row
            DataRow dr = dt.Rows[index];
            // Amount of empty columns
            int emptyQt = 0;
            // Run thourgh columns to check if any of them are emoty
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                // If empty, add +1 to the amount of empty columns
                if (string.IsNullOrWhiteSpace(dr.ItemArray[i].ToString()))
                    emptyQt++;
            }
            // if the amount of empty columns is equals to the amount of columns, it means that the whole row is empty
            return emptyQt == dr.Table.Columns.Count;
        }
		
		
		public void ValidateDataRow()
        {
            // Run through datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Check if the current row and the next 2 ones are empty
                if (isRowEmpty(dt, i) && isRowEmpty(dt, i + 1) && isRowEmpty(dt, i + 2))
                {
                    // Throws and alert that more than 2 rows 'in a row' are empty
                    Console.WriteLine("Mode than 2");
                    // add counter by 2 because the loop will add 1 more by itselft
                    i += 2;
                    continue;
                }
                else
                {
                    // Check if the previous row is filled, the current is empty and the next one is filled
                    // The first and the last has the operator "!" beacause if the row is empty the method to check 
                    // Will return false, so we have to deny it
                    if (!isRowEmpty(dt, i- 1) && isRowEmpty(dt, i) && !isRowEmpty(dt, i + 1))
                    {
                        // Throw alert for single empty row
                        Console.WriteLine("Empty row" + i.ToString());
                    }
                }
            }
            //DoHappyDance();
        }
