    bool myButtonWasClicked = false;
    private void Exit_Click(object sender, EventArgs e)
    {
      myButtonWasClicked = true;
      Application.Exit();
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (myButtonWasClicked)
      {
        e.Cancel = false;
      }
      else
      {
        e.Cancel = true;
      }
 
    }
