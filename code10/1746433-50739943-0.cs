    private void MyDGV_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
     if(e.KeyCode == Keys.Enter)
      {
        //First process your stuff
    
        //To stop Keypress from doing anything more:
        e.Handled = true;
      }
    }
