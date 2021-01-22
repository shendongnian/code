    private void panel1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        if (Control.ModifierKeys == Keys.Shift) SetSelectionEnd(e.X);
        else SetSelectionStart(e.X);
      }
    }
