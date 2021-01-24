    void clearLabels()
    {
        var labelList = this.Controls.OfType<GroupBox>();
 
        // GroupBoxes
        foreach (var item in labelList)
        {
            // Labels within GroupBox 
            foreach(var lbl in item.Controls.OfType<Label>()) 
            {
                lbl.Text = "0";
            }
        }
    }
