    public delegate void UpdateTextDelegate(string text);
    public void UpdateText(string text)
    {
      // Check we are on the right thread.
      if (!this.InvokeRequired)
      {
          // Update textbox here
      }
      else
      {
          UpdateTextDelegate updateText = new UpdateTextDelegate(this.UpdateText);
          // Executes a delegate on the thread that owns the control's underlying window handle.
          this.Invoke(updateText, new object[] { text });
      }
   }
