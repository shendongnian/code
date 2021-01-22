    public override void Write(string message) {
        if (this.output.InvokeRequired)
        {
            this.output.Invoke((MethodInvoker)delegate
            {
                this.output.AppendText(message);
            });
         }
         else
         {
             this.output.AppendText(message);
         }
    }
