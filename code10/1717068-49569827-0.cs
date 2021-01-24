     private void btnAddSave_Click(object sender, EventArgs e) {
       if (txtAddEmployerName.Text.Any(c => !(c == ' ' || char.IsLetter(c)))) {
         // Let's highlight (i.e. put keyboard focus) on the problem control
         if (txtAddEmployerName.CanFocus)
           txtAddEmployerName.Focus();
         MessageBox.Show("Letters only, please.", "Error");
         return; // seems redundant unless you have more code after the if 
       } 
     }
