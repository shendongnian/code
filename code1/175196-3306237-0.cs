     protected void RowDataBound(object sender, GridViewRowEventArgs e)
        { if (*Your condition (exemple date or higher value*)
                {
                e.Row.Attributes.Remove("Class");
                e.Row.Attributes.Add("Class", "GridView_New");
            }
