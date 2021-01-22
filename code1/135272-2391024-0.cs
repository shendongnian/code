        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            Button b = new Button();
            newForm.Controls.Add(b);
            b.Click += new EventHandler(click);
            newForm.FormClosed += new FormClosedEventHandler(form2_closed);
            newForm.FormClosing += new FormClosingEventHandler(form2_closing);
            this.Show();
            do
            {
              newForm.ShowDialog();
            } while (newForm.IsDisposed == false );               
        }
        private void click(object sender, EventArgs e)
        {
            ((Form)((Control)sender).Parent).ShowInTaskbar = !((Form)((Control)sender).Parent).ShowInTaskbar;
        }
        private void form2_closed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).Dispose();
        }
        private void form2_closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
                e.Cancel = true;
        }
