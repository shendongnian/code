    public partial class Form2:Form
    {
   
      public string SelectedPath {get; set;}
 
      private SelectPath_Click(object sender, EventArgs e)
      {
          // if path is a valid path {
          SelectedPath = txtBoxPath.text;
          this.DialogResult = DialogResult.OK;
          this.Close();
         // } else { CloseForm or Display an Error or ... }  
      } 
    }
