        private void btnReplaceLine_Click(object sender, RoutedEventArgs e)
        {
            string allLines = "This is line 1" + Environment.NewLine + "This is line 2" + Environment.NewLine + "This is line 3";
            string newLines = ReplaceLine(allLines, 2, "This is new line 2");
        }
