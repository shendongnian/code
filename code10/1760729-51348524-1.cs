    private KeyHandler ghk;
    bool isButtonClicked = false;
    public Form1()
    {
        InitializeComponent();
        // Keys.A is the key you want to subscribe
        ghk = new KeyHandler(Keys.A, this);
        ghk.Register();
    }
    private void HandleHotkey()
    {
         // Key 'A' pressed
         if(isButtonClicked)
         {
             // Put the boolean to false to avoid spamming the function with multiple press
             isButtonClicked = false;
             // Other Stuff
         }
    }
    private void btn_Click(object sender, EventArgs e)
    {
        // Do stuff
        isButtonClicked = true;
    }
    protected override void WndProc(ref Message m)
    {
        //0x0312 is the windows message id for hotkey
        if (m.Msg == 0x0312)
            HandleHotkey();
        base.WndProc(ref m);
    }
