void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
{
    MessageBox.Show(e.KeyChar.ToString());
    if (e.KeyCode == Keys.Enter){
      // This is handled and will be removed from Windows message pump
      e.Handled = true; 
    }
}
