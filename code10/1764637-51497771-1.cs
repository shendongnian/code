       private void DialogTxb_TextChanged(object sender, EventArgs e) { 
         try {
           //TODO: check ConexionData.CheckSectionName (re-)create connection if required
           using (MySqlDataReader selection = ConexionData.CheckSectionName(DialogTxb.Text)) {
             if (selection.Read()) {
               // Name exists (we've read it)
    
               DialogOk.Enabled = false;
               toolTip1.Show("La section existe", TooltibLb);
               DialogTxb.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffaaaa");
             }
             else {
               // Name doesn't exist: the cursor is empty (so we haven't read it)
    
               toolTip1.Hide(TooltibLb);
               DialogTxb.BackColor = Color.White;
               DialogOk.Enabled = true;
             }
           }
         }
         finally { 
           // finally: rain or shine the connection should be closed
           ConexionData.ConexionClose(); // Method to close connection
         }
       }
