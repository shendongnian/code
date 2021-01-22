            PagedDataSource objPage = new PagedDataSource();
            DataView dataView = listData.DefaultView;
            objPage.AllowPaging = true;
            objPage.DataSource = dataView;
            objPage.PageSize = PageSize;
            TotalPages = objPage.PageCount;
            objPage.CurrentPageIndex = CurrentPage - 1;
            //Convert PagedDataSource to DataTable
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
            //Here is your filtered DataTable
            return filterData; 
