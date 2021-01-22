    private void btnSubmit_Click(object sender, EventArgs e) 
    { 
        TradesDataSet.TradesRow newTradesRow = tradesDataSet.Trades.NewTradesRow(); 
 
        newTradesRow.ID = textBoxTradeID.Text;  
        newTradesRow.EntryPrice = textBoxEntryPrice.Text; 
        newTradesRow.ExitPrice = textBoxExitPrice.Text;             
 
        tradesDataSet.Trades.Rows.Add(newTradesRow); 
        //Wrong, this command says that what I have in the dataset is what is in 
        //the database.  You only use this if you manually update the dataset in 
        //the background.
        //tradesDataSet.Trades.AcceptChanges(); 
 
        try 
        { 
            //EndEdit then force a validate.
            this.tradesBindingSource.EndEdit();
            this.Validate();  
            //Internally this method calls .AcceptChanges();
            this.tradesTableAdapter.Update(this.tradesDataSet.Trades);                 
            MessageBox.Show("Update successful"); 
        } 
        catch (System.Exception ex) 
        { 
            MessageBox.Show("Update failed"); 
        } 
    }         
