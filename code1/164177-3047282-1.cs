    public class myDataGrid : System.Web.UI.WebControls.DataGrid 
    {
        protected override void OnPreRender(EventArgs e)
        {
            Table table = Controls[0] as Table;
    
            if (table != null && table.Rows.Count > 0)
            {
                // first row is the Table Header <thead>
                table.Rows[0].TableSection = TableRowSection.TableHeader;
                // last row is the Footer Header <tfoot> (comment for not using this)
                table.Rows[table.Rows.Count - 1].TableSection = TableRowSection.TableFooter;
    
                FieldInfo field = typeof(WebControl).GetField("tagKey", BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (TableCell cell in table.Rows[0].Cells)
                    field.SetValue(cell, HtmlTextWriterTag.Th);
            }
            base.OnPreRender(e);
        }
    }
