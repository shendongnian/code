        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Label l = new Label();
                l.Content = currentText.Text;
                RunScript(currentText.Text); // Send it to Python and get the result back
                l.Width = 792;
                l.Foreground = new SolidColorBrush(Colors.White);
                if (lstView.Items.Count == 1)
                    lstView.Items.Insert(0, l);
                else
                    lstView.Items.Insert(lstView.Items.Count-1, l);
                currentText.Text = String.Empty;
            }
        }
        /// This is sample
        private void RunScript(string text)
        {
            try
              {
                 // the Python Interpreter with the text
              } 
             Catch(Exception Ex)
             {
             }
        }
