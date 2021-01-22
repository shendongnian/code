    public partial class Form1 : Form
    {
        // Import GetFocus() from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();
    
        protected Control GetFocusControl()
        {
            Control focusControl = null;
            IntPtr focusHandle = GetFocus();
            if (focusHandle != IntPtr.Zero)
                // returns null if handle is not to a .NET control
                focusControl = Control.FromHandle(focusHandle);
            return focusControl;
        } 
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Control focusedControl = GetFocusControl();
            if (focusedControl != null && !(focusedControl is TextBox) && e.Control && e.KeyCode == Keys.C)//not a textbox and Copy
            {
                MessageBox.Show("@Form");
                e.Handled = true;
            }
        }
    
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.C)
                MessageBox.Show("@Control");
        }
    
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                MessageBox.Show("@Control");
        }
    }
