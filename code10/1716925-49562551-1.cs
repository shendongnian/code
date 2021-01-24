    Button button1 = new Button();
    button1.Text = "dynamic button";
    button1.Left = 10; button1.Top = 10; 
    textBox1.Click += new EventHandler(btn_click);
    this.Controls.Add(button1);
    private void btn_click()
    {
     }
