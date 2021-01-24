    private void Form1_Load(object sender, EventArgs e)
        {
            TextBox[] textboxes = new TextBox[] { textBox1 , textBox2, textBox3 };
            Button[] buttons = new Button[] { button1 };
            foreach (TextBox tbox in textboxes)
            {
                tbox.MouseEnter += new System.EventHandler(textbox_MouseEnter);
                tbox.MouseLeave += new System.EventHandler(textbox_MouseLeave);
            }
            foreach (var button in buttons)
            {
                button.MouseEnter += new System.EventHandler(btn_MouseEnter);
                button.MouseLeave += new System.EventHandler(btn_MouseLeave);
            }
        }
        private void btn_MouseEnter(object sender, System.EventArgs e)
        {
            var Button = (Button)sender;
            button1.BackColor = Color.Red;
            //label show
        }
        private void btn_MouseLeave(object sender, System.EventArgs e)
        {
            var Button = (Button)sender;
            button1.BackColor = SystemColors.Control;
            //label hide
        }
        private void textbox_MouseEnter(object sender, System.EventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.BackColor = Color.Red;
            //label show
        }
        private void textbox_MouseLeave(object sender, System.EventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.BackColor = SystemColors.Control;
            //label hide
        }
