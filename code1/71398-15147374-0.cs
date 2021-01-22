    public class TextBoxEx : TextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Back | Keys.Control))
            {
                for (int i = this.SelectionStart - 1; i > 0; i--)
                {
                    switch (Text.Substring(i, 1))
                    {    //set up any stopping points you want
                        case " ":
                        case ";":
                        case ",":
                        case "/":
                        case "\\":                        
                            Text = Text.Remove(i, SelectionStart - i);
                            SelectionStart = i;
                            return true;
                        case "\n":
                            Text = Text.Remove(i - 1, SelectionStart - i);
                            SelectionStart = i;
                            return true;
                    }
                }
                Clear();        //in case you never hit a stopping point, the whole textbox goes blank
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }  
    }
