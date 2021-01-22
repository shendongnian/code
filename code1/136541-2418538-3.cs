    protected void GridViewDice_RowDataBound(object sender, GridViewRowEventArgs e) 
    { 
     
     
        DataTable diceTable = _gm.GetDice(_gameId); 
        for (int i = 0; i < GameRules.ColumnsOfDice; i++) 
        { 
            if(e.Row.RowIndex > -1) 
            { 
                Button btn = new Button();
                btn.CommandArgument = diceTable.Rows[e.Row.RowIndex][i].ToString(); 
                btn.Attributes.Add("OnClick", "btn_Clicked");
                
                e.Row.Cells[i].Controls.Add(btn);
            }
        }
    }
