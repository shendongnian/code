       private void tbSomeText_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Modifiers != Keys.Shift) {
                MessageBox.Show("You Pressed b");
            }
            else if (e.KeyCode == Keys.A && e.Modifiers == Keys.Shift) {
                MessageBox.Show("You Pressed Shift+A");
            }
        }
