    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)  
    {     
     if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;
                string abc = ((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString();         
                gvr.Attributes.Add("OnClick", "javascript:location.href='Default.aspx?id=" + abc + "'");
            }         
    
       }  
    }  
