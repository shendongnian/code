        this.cmbStatusBox.Items.Clear();
        
        if(mainForm.boolEdit)
        {
             this.cmbStatusBox.Items.AddRange(new object[] {
                "Cooking",
                "In-transit",
                "Delivered"});
        }
        else
        {
             this.cmbStatusBox.Items.AddRange(new object[] {
                 "Ordered"});
        }
