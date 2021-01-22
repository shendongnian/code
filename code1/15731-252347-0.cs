        private void AddConsoleComment(string comment)
        {
            textBoxConsole.Text += comment + System.Environment.NewLine;
            textBoxConsole.Select(textBoxConsole.Text.Length,0);
            textBoxConsole.ScrollToCaret();
        }
