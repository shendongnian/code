    public Form1 : Form
    {
        public Form1()
        {
            ...
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }
    
        private async Task button1_Click(object sender, EventArgs e) // line A
        {
            await YourLogic(e.foo); //optional configure await.
        }
  
        private async Task YourLogic(your parameters)
        {
            // do stuff
        }
    }
