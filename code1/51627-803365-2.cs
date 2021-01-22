PFA(form => SetControlText(form.Richbox1, "Test"));
public void SetControlText(Control control, string text)
{ 
  control.Text = text;  
  // choose control type for which you want to add new line
  if(control is RichTextbox || control is TextBox || control is ... )
    control.Text += Environment.NewLine;
}
