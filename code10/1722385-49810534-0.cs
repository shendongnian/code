    public void ExportToExcel(System.Web.UI.WebControls.GridView controlname, string sheetname)
        {
            HttpContext context = HttpContext.Current;
            context.Response.ClearContent();
            context.Response.Buffer = true;
            context.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", sheetname + ".txt"));
            context.Response.ContentType = "application/text";
           // context.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", sheetname + ".xls"));
           // context.Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            //Change the Header Row back to white color
            controlname.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < controlname.HeaderRow.Cells.Count; i++)
            {
                controlname.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            //This loop is used to apply stlye to cells based on particular row
            foreach (GridViewRow gvrow in controlname.Rows)
            {
                gvrow.BackColor = Color.White;
                if (j <= controlname.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                        }
                    }
                }
                j++;
            }
            controlname.RenderControl(htw);
            context.Response.Write(sw.ToString());
            context.Response.End();
        }
