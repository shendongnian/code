    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
       // What to do with UI
       Action action = () => {
          MessageBox.Show(textBox1.Text);
          MessageBox.Show(richTextBox1.Text);
       }
       if (InvokeRequired)  // We are in some background thread, Invoke required
         Invoke(action);
       else                 // We are in UI (main) thread, just call the action
         action(); 
    }
