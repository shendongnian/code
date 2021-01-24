    public void single_button_Click(object sender, EventArgs e)
    {
      Button btn = (Button)sender;
      if (btn.BackColor == Color.Red)
      {
        btn.BackColor = SystemColors.Control;
      }
      else if (btn.BackColor == SystemColors.Control)
      {
        btn.BackColor = Color.Red;
      }
    }
