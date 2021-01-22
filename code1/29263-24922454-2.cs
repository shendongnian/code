    public class ParsableTextBox<T> : TextBox
    {
        TryParser BackingTryParse;
        string PreviousText;
        T BackingResult;
        public ParsableTextBox()
            : this(null)
        {
        }
        public ParsableTextBox(TryParser tryParse)
        {
            TryParse = tryParse;
            TextChanged += ParsableTextBox_TextChanged;
        }
        public delegate bool TryParser(string text, out T result);
        public TryParser TryParse
        {
            set
            {
                Enabled = !(ReadOnly = value == null);
                BackingTryParse = value;
            }
        }
        public bool HasResult { get; private set; }
        public T Result
        {
            get
            {
                return HasResult ? BackingResult : default(T);
            }
        }
        void ParsableTextBox_TextChanged(object sender, EventArgs e)
        {
            if (BackingTryParse != null)
            {
                HasResult = BackingTryParse(Text, out BackingResult);
            }
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
