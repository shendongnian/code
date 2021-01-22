    public partial class main : Form
    { 
        protected override CreateParams CreateParams 
        {
        get
            {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;
            return cp;
            }
        }
    }
