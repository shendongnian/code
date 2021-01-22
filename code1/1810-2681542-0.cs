        public void MakeCellValueListDropDownList(UltraWebGrid grid, string columnName, string valueListName, string[] listArray)
        {
            //Set the column to be a dropdownlist
            UltraGridColumn Col = grid.Columns.FromKey(columnName);            
            Col.Type = ColumnType.DropDownList;
            Col.DataType = "System.String";
            
            try
            {
                ValueList ValList = grid.DisplayLayout.Bands[0].Columns.FromKey(columnName).ValueList;
                ValList.DataSource = listArray;
                foreach (string item in listArray)
                {
                    ValList.ValueListItems.Add(item);
                }
                ValList.DataBind();
            }
            catch (ArgumentException)
            {
            }
        }
