          private bool ShowClose()
       {
           //Yes or no message box to exit the application
           DialogResult Response;
           Response = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
           return Response == DialogResult.Yes;
       }
    
          public void button1_Click(object sender, EventArgs e)
       {
           Close();
       }
    
    private void xGameForm_FormClosing(object sender, FormClosingEventArgs e)
       {
          e.Cancel = !ShowClose();
       }
