void btnValidate_Click(object sender, EventArgs e)
{
  foreach( Control c in this.Controls )
  {
    if( c is TextBox )
    {
      TextBox tbToValidate = (TextBox)c;
      Validate(tbToValidate.Text);
    }
  }
}
