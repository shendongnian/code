                if (myPanel.Visible)
                {
                    myPanel.Visible = false;
    
                    tableLayoutPanel1.SetCellPosition(myPanel, new 
                    TableLayoutPanelCellPosition(0, 1));
                    tableLayoutPanel1.SetColumnSpan(myPanel, 2);
    
                }
                else
                {
                    myPanel.Visible = true;
    
                    tableLayoutPanel1.SetCellPosition(myPanel, new TableLayoutPanelCellPosition(1, 1));
                    tableLayoutPanel1.SetColumnSpan(myPanel, 1);
                }    
