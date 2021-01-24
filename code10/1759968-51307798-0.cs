            private void TextBox_Validating(object sender, EventArgs e)
        {
            if (!((TextBox)sender).AutoCompleteCustomSource.Contains(((TextBox)sender).Text) && ((TextBox)sender).TextLength > 0)
            {
                ((TextBox)sender).AutoCompleteCustomSource.AddRange(new string[]
                {
                   ((TextBox)sender).Text,
                });
                SaveHistoryTextBox(((TextBox)sender));
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
