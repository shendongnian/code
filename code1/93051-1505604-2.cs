    public Form1()
    {
        this.InitializeComponent();
        
        // Just to illustrate - can be done in the designer.
        this.timer.Interval = 1000; // One second.
        this.timer.Enable = true;
    }
    private Int32 state = 0;
    private void timer_Tick(Object sender, EventArgs e)
    {
        if ((0 <= this.state) && (this.state < 30)) // Hit text box 1 30 times.
        {
            SendKeys.Send(this.richTextBox1.Text);
            SendKeys.Send("{ENTER}");
        }
        else if (this.state == 30) // Hit text box 2 once.
        {
            SendKeys.Send(this.richTextBox2.Text);
            SendKeys.Send("{ENTER}");
        }
        else if ((31 <= this.state) && (this.state < 40)) // Do nothing 9 times.
        {
            // Do nothing.
        }
        else
        {
            throw new InvalidOperationException(); // Unexpected state.
        }
        // Update state.
        this.state = (this.state + 1) % 40;
    }
