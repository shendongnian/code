    public partial  class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();
    
        public Form1()
        {
            InitializeComponent();
    
            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt,
                Keys.F12);
        }
    
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            label1.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
        }
    }
