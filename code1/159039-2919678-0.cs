    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
          if (e.KeyCode == Keys.Multiply) 
          {
            e.Handled = true;
            tb.Text += "."
          }
        }
