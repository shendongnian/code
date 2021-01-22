    public partial class MyTextBox : UserControl
    {
       ...
       ...
       ...
       public void DisableMyTextBox()
        {
            this.txt.Enabled = false;  //txt is the name of Winform-Textbox from my designer
            this.Enabled = true;
        }
        public void EnableMyTextBox()
        {
            this.txt.Enabled = true;
            this.Enabled = true;
        }
        //set the tooltip from properties tab in designer or wherever
    }
