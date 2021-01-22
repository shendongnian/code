     protected override void OnKeyDown(KeyEventArgs e)
     {
          if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
          {
                MessageBox.Show("Hello world");
          }
          base.OnKeyDown(e);
      }
