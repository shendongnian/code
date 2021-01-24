       public partial class StockSearch : Form {
         ...
         private void buttonOK_Click(object sender, EventArgs e) {
           // Validation (if any)
           ...
           // Validation passed, we close the form with "OK" dialog result
           DialogResult = DialogResult.OK; 
         }
       }
