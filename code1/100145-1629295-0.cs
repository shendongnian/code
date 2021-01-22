MainFrom form = new MainForm();
form.Show();
if (form.go())
{
  Application.Run(form);
}
else
{
  form.Close();
}
class MainFrom
{
  public bool go()
  {
    LoginFrom lf = new LoginForm()
    if (lf.ShowDialog() != DialogResult.OK)
    {
      return false;
    }
  }
}
