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
        Decimal n1 = this.numericUpDown1.Value;
        Decimal n2 = this.numericUpDown2.Value;
        if ((0 <= this.state) && (this.state < n1))
        {
            SendKeys.Send(this.richTextBox1.Text);
            SendKeys.Send("{ENTER}");
        }
        else if (this.state == n1)
        {
            SendKeys.Send(this.richTextBox2.Text);
            SendKeys.Send("{ENTER}");
        }
        else if ((n1 <= this.state) && (this.state < n1 + n2))
        {
            // Do nothing.
        }
        else
        {
            // Reset state to resolve race conditions.
            this.state = 0;
        }
        // Update state.
        this.state = (this.state + 1) % (n1 + n2);
    }
