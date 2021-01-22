    public partial class frmCaptureMouse : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetCapture(IntPtr hWnd);
        public frmCaptureMouse()
        {
            InitializeComponent();
        }
        private void frmCaptureMouse_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                lblCoords.Text = e.Location.X.ToString() + ", " + e.Location.Y.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                SetCapture(this.Handle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
