        private void txtAutoComplete_KeyUp(object sender, KeyEventArgs e)
        {
            String text = txtAutoComplete.Text;
            if (text.EndsWith(" "))
            {
                string[] suggestions = GetNameSuggestions( text ); //put [text + " "] at the begin of each array element
                txtAutoComplete.AutoCompleteCustomSource.Clear();
                txtAutoComplete.AutoCompleteCustomSource.AddRange( suggestions );
            }
        }
