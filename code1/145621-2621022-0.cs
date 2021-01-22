    delegate void SetTextCallback(string text);
     public void UpdateLog(string mxID, string text)
     {
         if (txtOutput.InvokeRequired)
         {
            SetTextCallback d = new SetTextCallback(UpdateProgressBar);
            this.BeginInvoke(d, new object[] { text });
         }
         else
         {
            UpdateProgressBar(text);
         }
     } 
