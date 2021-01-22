    private void bttnfilter_Click(object sender, ImageClickEventArgs e)
    {
        string filterText = TextBox1.Text.Trim().ToLower();
    
        if (!String.IsNullOrEmpty(filterText))
            SqlDataSource1.FilterExpression = 
                string.Format("field LIKE '%{0}%'",filterText);         
    }
