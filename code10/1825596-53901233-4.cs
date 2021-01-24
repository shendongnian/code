    public partial class Monitor3 : Form
    {
        Monitor4 mo4 = null;
        private void Monitor3_Load(object sender, EventArgs e)
        {
            mo4 = new Monitor4();
            //Show Monitor4 on the right side of this Form
            mo4.Location = new Point(this.Right + 10, this.Top);
            mo4.Show(this);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string NewText = textBox1.Text;
            switch (NewText)
            {
                case "[Some text 1]":
                    mo4.UpdatePictureBox(@"[Images1 Path]");
                    break;
                case "QUEBEC - ALPHA - TANGO - ALPHA - ROMEO - ":
                    mo4.UpdatePictureBox(@"[Images2 Path]");
                    break;
                case "[Sme text 3]":
                    mo4.UpdatePictureBox(@"[Images3 Path]");
                    break;
            }
        }
    }
