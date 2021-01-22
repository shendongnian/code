        protected void Page_Init(object sender, EventArgs e) 
    { 
        Table tb = new Table(); 
        tb.ID = "tb1"; 
     
        for (int i = 0; i < iCounter; i++) 
        { 
            TableRow tr = new TableRow(); 
            TextBox tbox = new TextBox(); 
            TextBox tLabel = new Label();
            tbox.ID = i.ToString(); 
    
    	tLabel.width = 10;
     
            TableCell tc = new TableCell(); 
            tc.Controls.Add(tbox);
    	tc.Controls.Add(tLabel);
            tc.Controls.Add(tbox);
    	tc.Controls.Add(tLabel);
            tc.Controls.Add(tbox);
    	tc.Controls.Add(tLabel);
            tr.Cells.Add(tc); 
            tb.Rows.Add(tr); 
        } 
        pnlScheduler.Controls.Add(tb); 
    }
