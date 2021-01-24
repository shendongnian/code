    public partial class Form1 : Form
    { 
        private void mCANoeProgProgressChangedInternal(object sender, EventArgs e)
        {
	        ProgressBarForm frm = new ProgressBarForm(); 
            frm.DoSomething(value);
        }
    }
