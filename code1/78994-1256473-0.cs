    private void FormClosing(object sender, FormClosingEventArgs e)
    {
         if (e.CloseReason == CloseReason.UserClosing)
         {
            e.Cancel = true;
            Hide();
         }
    }
