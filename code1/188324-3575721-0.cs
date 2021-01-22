    MouseEnter += new EventHandler(delegate(object sender, EventArgs e)
        {
            SetButtonColour(Color.Blue);
        });
    MouseLeave += new EventHandler(delegate(object sender, EventArgs e)
        {
            SetButtonColour(Color.Red);
        });
      
    public void SetButtonColour(Color colour)
        {
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is Button) Controls[i].BackColor = Color.Blue;
        }
