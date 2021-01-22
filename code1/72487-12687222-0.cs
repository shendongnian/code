    tlpFields.RowStyles.Clear();  //first u must clear rowStyles
    for (int ii = 0; ii < 5; ii++)
            {
                Label l1= new Label();
                TextBox t1 = new TextBox();
                
                l1.Text = "field : ";
                
                tlpFields.Controls.Add(l1, 0, ii);  // add label in column0
                tlpFields.Controls.Add(t1, 1, ii);  // add textbox in column1
                tlpFields.RowStyles.Add(new RowStyle(SizeType.Absolute,30)); // 30 is the rows space
               
            }
