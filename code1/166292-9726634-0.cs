    public partial class Form1 : Form
    {
        private static readonly System.Collections.Generic.ICollection<System.Windows.Forms.Keys) ExcludeKeys = new System.Collections.Generic.HashSet<System.Windows.Forms.Keys)()
        {
            System.Windows.Forms.Keys.None,
            System.Windows.Forms.Keys.Shift,
            System.Windows.Forms.Keys.ShiftKey,
            System.Windows.Forms.Keys.LShiftKey,
            System.Windows.Forms.Keys.RShiftKey,
            System.Windows.Forms.Keys.Alt,
            System.Windows.Forms.Keys.Control,
            System.Windows.Forms.Keys.ControlKey,
            System.Windows.Forms.Keys.LControlKey,
            System.Windows.Forms.Keys.RControlKey,
            System.Windows.Forms.Keys.CapsLock,
            System.Windows.Forms.Keys.NumLock,
            System.Windows.Forms.Keys.LWin,
            System.Windows.Forms.Keys.RWin
        }
        private bool isKeyPressed = false;
        public Form1()
        {
            InitializeComponent();
            this.textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            this.textBox1.KeyUp += new KeyEventHandler(textBox1_KeyUp);
        }
        void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ExcludeKeys.Contains(e.KeyCode))
            {
                isKeyPressed = false;
            }
        }
        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ExcludeKeys.Contains(e.KeyCode))
            {
                e.SuppressKeyPress = isKeyPressed;
                isKeyPressed = true;
            }
        }
    }
