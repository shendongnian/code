    delegate void updateLabelTextDelegate(string newText);
    private void updateLabelText(string newText)
    {
         if (label1.InvokeRequired)
         {
              // this is worker thread
              updateLabelTextDelegate del = new updateLabelTextDelegate(updateLabelText);
              label1.Invoke(del, new object[] { newText });
         }
         else
         {
              // this is UI thread
              label1.Text = newText;
         }
    }
