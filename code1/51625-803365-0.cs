PFA(form => SetControlText(form.Richbox1, "Test"));
public void SetControlText(Control control, string text)
{ 
  control.AppendText(text + Environment.NewLine);
}
