    private void Form_KeyDown(object sender, KeyEventArgs e) { 
       if (e.Control && e.KeyCode == Keys.A) {
          ItemA_Click(...);
       } else if (e.Control && e.KeyCode == Keys.B) { 
          ItemB_Click(...);
       } else if (e.Control && e.KeyCode == Keys.C) { 
          ItemC_Click(...);
       }
    }
