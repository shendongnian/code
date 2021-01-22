    private void Form1_Load(object sender, EventArgs e)
    {
        Form2 newForm = new Form2();
        Button b = new Button();
        newForm.Controls.Add(b);
        b.Click += new EventHandler(click);
        this.Show();
        // add this line of code...
        newForm.ShowInTaskbar = false; 
        newForm.ShowDialog();
    }
    private void click(object sender, EventArgs e)
    {
        ((Form)((Control)sender).Parent).ShowInTaskbar = false;
    }
