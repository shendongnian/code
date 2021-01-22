    public class IntTextBox : TextBox
    {
        string PreviousText = "";
        int BackingResult;
        public IntTextBox()
        {
            TextChanged += IntTextBox_TextChanged;
        }
        public bool HasResult { get; private set; }
        public int Result
        {
            get
            {
                return HasResult ? BackingResult : default(int);
            }
        }
        void IntTextBox_TextChanged(object sender, EventArgs e)
        {
            HasResult = int.TryParse(Text, out BackingResult);
            if (HasResult || string.IsNullOrEmpty(Text))
            {
                // Commit
                PreviousText = Text;
            }
            else
            {
                // Revert
                var changeOffset = Text.Length - PreviousText.Length;
                var previousSelectionStart =
                    Math.Max(0, SelectionStart - changeOffset);
                Text = PreviousText;
                SelectionStart = previousSelectionStart;
            }
        }
    }
