    public partial class InterForm : Form
    {
        public void ClearAll() //CLEAR TEXTBOXES
        {
            foreach (var box in this.Controls.OfType<TextBox>())
            {
                box.Text = "";
            }
        }
     }
