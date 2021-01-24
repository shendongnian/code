    protected override void OnFormClosing(FormClosingEventArgs e) {
      if (!myView1.UserControlOK()) {
        MessageBox.Show("TextBox is empty.");
        e.Cancel = true;
      }
      base.OnFormClosing(e);
    }
