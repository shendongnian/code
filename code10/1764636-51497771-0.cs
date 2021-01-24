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
