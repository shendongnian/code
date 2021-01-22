    public class ConsoleTextBox: TextBox
    {
        private List<string> contents = new List<string>();
        private const int MAX = 50;
        public void WriteLine(string input)
        {
            if (contents.Count == MAX)
                contents.RemoveAt(MAX-1);
            contents.Insert(0, input);
            Rewrite();
        }
        private void Rewrite()
        {
            var sb = new StringBuilder();
            foreach (var s in contents)
            {
                sb.Append(s);
                sb.Append(Environment.NewLine);
            }
            this.Text = sb.ToString();
        }
    }
