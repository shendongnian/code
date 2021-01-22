            System.Collections.IEnumerator pagedData = objPage.GetEnumerator();
            DataTable filteredData = new DataTable();
            bool flagToCopyDTStruct = false;
            while (pagedData.MoveNext())
            {
                DataRowView rowView = (DataRowView)pagedData.Current;
                if (!flagToCopyDTStruct)
                {
                    filteredData = rowView.Row.Table.Clone();
                    flagToCopyDTStruct = true;
                }
                filteredData.LoadDataRow(rowView.Row.ItemArray, true);
            }
            return filterData; //Here is your filtered DataTable
