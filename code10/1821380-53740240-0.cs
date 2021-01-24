    this.button1.Click += new System.EventHandler(this.button1_Click);
    this.button2.Click += this.button1_Click;
    private void button1_Click(object sender, EventArgs e)
            {
                var btn = sender as Button;
    
                switch(btn.Name.ToLower())
                {
                    case "button1":
                        MessageBox.Show("Add 1");
                        break;
                    case "button2":
                        MessageBox.Show("Add 2");
                        break;
                    default:
                        MessageBox.Show("Button not found");
                        break;
                }
            }
