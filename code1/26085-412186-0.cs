            string TextBoxPrefix = "textBx";
            foreach (Control CurrentControl in this.Controls)
            {
                if (CurrentControl is TextBox)
                {
                    if (CurrentControl.Name.StartsWith(TextBoxPrefix)) {
                        int TextBoxNumber = System.Convert.ToInt16(CurrentControl.Name.Substring(TextBoxPrefix.Length));
                        if (TextBoxNumber <= (list.Count - 1))
                        {
                            CurrentControl.Text = list[TextBoxNumber].ToString();
                        }
                    }
                }
            }
