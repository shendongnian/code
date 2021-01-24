    void clearLabels()
    {
        var groupBoxes = this.Controls.OfType<GroupBox>();
 
        // GroupBoxes
        foreach (var item in groupBoxes)
        {
            // Labels within GroupBox 
            foreach(var lbl in item.Controls.OfType<Label>()) 
            {
                lbl.Text = "0";
            }
        }
    }
