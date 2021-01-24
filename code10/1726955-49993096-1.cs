    public class Form1 : Form
    {
       private void Form1_Load(object sender, EventArgs e)
       {
           
       }
        protected override OnFontChanged(EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                if(control is PictureBox)
                {
                   control.Font = new Font(<Your constant defined font>);;
                }
            }
        }
    }
