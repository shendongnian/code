    private void btnEval_Click(object sender, EventArgs e)
            {
                txtOutput.Text = "";
                try
                {
                    if (Regex.IsMatch(txtInput.Text, txtExpression.Text, getRegexOptions()))
                    {
                        MatchCollection matches = Regex.Matches(txtInput.Text, txtExpression.Text, getRegexOptions());
    
                        foreach (Match match in matches)
                        {
                            txtOutput.Text += match.Value + "\r\n";
                        }
    
                        int i = 0;
                    }
                    else
                    {
                        txtOutput.Text = "The regex cannot be matched";
                    }
                }
                catch (Exception ex)
                {
                    // Most likely cause is a syntax error in the regular expression
                    txtOutput.Text = "Regex.IsMatch() threw an exception:\r\n" + ex.Message;
                }
    
            }
    
            private RegexOptions getRegexOptions()
            {
                RegexOptions options = new RegexOptions();
          
                return options;
            }
