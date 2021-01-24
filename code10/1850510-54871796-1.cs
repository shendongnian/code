    public void updateOutputBox() {
        while (true) {
              if (outputBox.InvokeRequired)
               {
                     outputBox.Invoke(new MethodInvoker(delegate {
                         outputBox.Width = this.Width - 150;
                         outputBox.Height = this.Height - (outputBox.Location.Y + 50);
                         outputBox.Location = new Point(100, connectionStatus.Height + 50);
                    }));
                }
        }
    }
 
