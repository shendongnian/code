    private delegate void SetLabelSub(string NewText);
    private void SetLabel(string NewText)
    {
     if (this.InvokeRequired()) {
      SetLabelSub Del = new SetLabelSub(SetLabel);
      this.Invoke(Del, new object[] { NewText });
     } else {
      SomeLabel.Text = NewText;
     }
    }
