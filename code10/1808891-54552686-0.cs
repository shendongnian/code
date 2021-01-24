    public Form1 : Form
    {
        public Form1()
        {
            ...
            this.button1.Click += 
                 new System.EventHandler(
                     async (sender, events) => await this.button1_Click(sender, events)
                 );
        }
        private async Task button1_Click(object sender, EventArgs e) // line A
        {
        }
    }
