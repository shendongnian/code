    public class Form1 : Form
    {
        private List<Font> PBFonts = new List<Font>();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
               if(control is PictureBox)
               {
                   this.PBFonts.Add(control.Font);
               }
            }
        }
        protected override OnFontChanged(EventArgs e)
        {
            int index = 0;
            foreach(Control control in this.Controls)
            {
               if(control is PictureBox picture)
               {
                   picture.Font = this.PBFonts[index];
               }
               index++;
            }
        }
    }
