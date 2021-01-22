     public static Workbook CreateWorkbook(GridView gridView)
        {
            int pageSize = gridView.PageSize;
            gridView.PageSize = 10000000;
            gridView.DataBind();
            Workbook workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets.Add("Export");
            WorksheetStyle style = workbook.Styles.Add("headerStyle");
            style.Font.Bold = true;
            style = workbook.Styles.Add("defaultStyle");
            style.Alignment.WrapText = true;
            style = workbook.Styles.Add("infoStyle");
            style.Font.Color = "Red";
            style.Font.Bold = true;
            sheet.Table.Rows.Add(new WorksheetRow());
            WorksheetRow headerRow = new WorksheetRow();
            foreach (DataControlFieldHeaderCell cell in gridView.HeaderRow.Cells)
            {
                if (!string.IsNullOrEmpty(cell.Text))
                    headerRow.Cells.Add(cell.Text, DataType.String, "headerStyle");
                else
                    foreach (Control control in cell.Controls)
                    {
                        LinkButton linkButton = new LinkButton();
                        try
                        {
                            linkButton = (LinkButton)control;
                        }
                        catch { }
                        if (!string.IsNullOrEmpty(linkButton.Text))
                            headerRow.Cells.Add(linkButton.Text, DataType.String, "headerStyle");
                        else
                        {
                            Label label = new Label();
                            try
                            {
                                label = (Label)control;
                            }
                            catch { }
                            if (!string.IsNullOrEmpty(label.Text))
                                headerRow.Cells.Add(label.Text, DataType.String, "headerStyle");
                        }
                    }
            }
            sheet.Table.Rows.Add(headerRow);
            foreach (GridViewRow row in gridView.Rows)
            {
                WorksheetRow wrow = new WorksheetRow();
                foreach (TableCell cell in row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        if (control.GetType() == typeof(Label))
                        {
                            wrow.Cells.Add(((Label)control).Text, DataType.String, "defaultStyle");
                        }
                    }
                }
                sheet.Table.Rows.Add(wrow);
            }
            gridView.PageSize = pageSize;
            return workbook;
        }
