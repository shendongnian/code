    private bool m_isExiting;
       private void xGameForm_FormClosing(object sender, FormClosingEventArgs e)
       {
           if ( !m_isExiting ) {
             //Yes or no message box to exit the application
             DialogResult Response;
             Response = MessageBox.Show("Are you sure you want to Exit?", "Exit",   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
             if (Response == DialogResult.Yes) {
               m_isExiting = true;
               Application.Exit();
             }
       }
       public void button1_Click(object sender, EventArgs e)
       {
           Application.Exit();
       }
