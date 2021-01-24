     private void btnAddSave_Click(object sender, EventArgs e) {
       // char.IsLetter - any unicode letter, not necessary English ones 
       // e.g. Russian (Cyrillic) are included as well: Это тоже буквы
       // In case you want a..z A..Z only
       //   c => c == '' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z'
       if (txtAddEmployerName.Text.Any(c => !(c == ' ' || char.IsLetter(c)))) {
         // Let's highlight (i.e. put keyboard focus) on the problem control
         if (txtAddEmployerName.CanFocus)
           txtAddEmployerName.Focus();
         MessageBox.Show("Letters only, please.", "Error");
         return; // seems redundant unless you have more code after the if 
       } 
     }
