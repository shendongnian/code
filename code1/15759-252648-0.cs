        public static void CreateExcelFromDataTable(string filename, DataTable dt) {
 
            DataGrid grid = new DataGrid();
            grid.HeaderStyle.Font.Bold = true;
            grid.DataSource = dt;
            grid.DataMember = dt.TableName;
            grid.DataBind();
            // render the DataGrid control to a file
            using (StreamWriter sw = new StreamWriter(filename)) {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw)) {
                    grid.RenderControl(hw);
                }
            }
        }
