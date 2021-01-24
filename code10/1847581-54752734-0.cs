    protected override void OnMouseDown(MouseEventArgs e) {
      base.OnMouseDown(e);
      if (tabControl1.Bounds.Contains(e.Location)) {
        MessageBox.Show("tab space clicked");
      }
    }
