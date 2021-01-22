    void Button2_Click(object o, EventArgs e) {
        Button myButton = (Button)o;
        GridViewRow row = (GridViewRow)muButton.Parent.Parent;
    
        string value1 = row.Cells[0].Text;
        string value2 = row.Cells[1].Text;
        ...
    }
