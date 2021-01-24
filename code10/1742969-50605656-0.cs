    public partial class Form1 : Form {
    
        private IList<RichTextBox> AffectedBoxes { get; set; }
    
        public Form1() {
            // List must be initialized before we can add to it
            AffectedBoxes = new List<RichTextBox>();
            // other stuff ...
        }
    
        private void P_Click(object sender, EventArgs e) {
            // ...
     
            RichTextBox tb = new RichTextBox(); 
            AffectedBoxes.Add(tb); // remember that we have to handle this RichTextBox 
    
            // ...
        } 
    
        private void PicFont_Click(object sender, EventArgs e) {
            fontDialog1.ShowDialog();
    
            // loop over all affected boxes
            foreach (var box in AffectedBoxes) {
                box.SelectionFont = fontDialog1.Font;
            }
        } 
    }
