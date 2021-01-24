    <asp:GridView ID="GrdAccess" runat="server" AutoGenerateColumns="false" Width="70%" AllowPaging="true" PageSize="20" CssClass="Grid" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000" PagerStyle-CssClass="pgr" OnPageIndexChanging="GrdAccess_PageIndexChanging"></asp:GridView>
  
    protected void ExportToExcel(object sender, EventArgs e)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
        
                    //To Export all pages
                    GrdAccess.AllowPaging = false;
                    this.getProjectDetails();
        
                    GrdAccess.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in GrdAccess.HeaderRow.Cells)
                    {
                        cell.BackColor = GrdAccess.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in GrdAccess.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = GrdAccess.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = GrdAccess.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }
        
                    GrdAccess.RenderControl(hw);
        
                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        
        
        public override void VerifyRenderingInServerForm(Control control)
            {
        
            }
