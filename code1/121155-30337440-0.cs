        public partial class frmFirma : Form, FormExtensions
        {
            public frmFirma()
            {
                InitializeComponent();
            }
            public void CenterForm(Form forma)
            {
                forma.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width / 2 - forma.Width / 2,
                Screen.PrimaryScreen.WorkingArea.Height / 2 - forma.Height / 2);
            }
        }
