        private delegate void AddMessageCallback(string message, Color color);
        public void AddMessage(string message)
        {
            Color color = Color.Empty;
            string searchedString = message.ToLowerInvariant();
            if (searchedString.Contains("failed")
                || searchedString.Contains("error")
                || searchedString.Contains("warning"))
            {
                color = Color.Red;
            }
            else if (searchedString.Contains("success"))
            {
                color = Color.Green;
            }
            AddMessage(message, color);
        }
        public void AddMessage(string message, Color color)
        {
            if (_richTextBox.InvokeRequired)
            {
                AddMessageCallback cb = new AddMessageCallback(AddMessageInternal);
                _richTextBox.BeginInvoke(cb, message, color);
            }
            else
            {
                AddMessageInternal(message, color);
            }
        }
        private void AddMessageInternal(string message, Color color)
        {
            string formattedMessage = String.Format("{0:G}   {1}{2}", DateTime.Now, message, Environment.NewLine);
            if (color != Color.Empty)
            {
                _richTextBox.SelectionColor = color;
            }
            _richTextBox.SelectedText = formattedMessage;
            _richTextBox.SelectionStart = _richTextBox.Text.Length;
            _richTextBox.ScrollToCaret();
        }
