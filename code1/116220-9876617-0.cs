    public enum InputType
    {
        PositiveInteger,
        PositiveDecimal,
        PositiveNullableInteger,
        PositiveNullableDecimal,
    }
    public static class Input
    {
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.RegisterAttached("Type", typeof(InputType), typeof(TextBox),
                                                new PropertyMetadata(default(InputType), OnTypeChanged));
        public static void SetType(TextBox element, InputType value)
        {
            element.SetValue(TypeProperty, value);
        }
        public static InputType GetType(TextBox element)
        {
            return (InputType)element.GetValue(TypeProperty);
        }
        private class TextSelection
        {
            public string Text { get; private set; }
            public int SelectionStart { get; private set; }
            public int SelectionLength { get; private set; }
            public TextSelection(string text, int selectionStart, int selectionLength)
            {
                Text = text;
                SelectionStart = selectionStart;
                SelectionLength = selectionLength;
            }
        }
        private static readonly DependencyProperty PreviousTextSelectionProperty =
            DependencyProperty.RegisterAttached("PreviousTextSelection", typeof(TextSelection),
            typeof(TextBox), new PropertyMetadata(default(TextSelection)));
        private static void SetPreviousTextSelection(TextBox element, TextSelection value)
        {
            element.SetValue(PreviousTextSelectionProperty, value);
        }
        private static TextSelection GetPreviousTextSelection(TextBox element)
        {
            return (TextSelection)element.GetValue(PreviousTextSelectionProperty);
        }
        private static void OnTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (UIApplication.DesignMode)
                return;
            var textBox = (TextBox)d;
            textBox.TextChanged += OnTextChanged;
            textBox.SelectionChanged += OnSelectionChanged;
        }
        /// <summary>
        /// Determines whether the specified text is valid.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <returns>
        ///   <c>true</c> if the specified text is valid; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsValid(string text, InputType inputType)
        {
            switch (inputType)
            {
            case InputType.PositiveInteger:
                int i;
                return int.TryParse(text, out i);
            case InputType.PositiveDecimal:
                decimal d;
                return decimal.TryParse(text, out d) && d >= 0;
            case InputType.PositiveNullableInteger:
                return text.IsNullOrEmpty() || IsValid(text, InputType.PositiveInteger);
            case InputType.PositiveNullableDecimal:
                return text.IsNullOrEmpty() || IsValid(text, InputType.PositiveDecimal);
            default:
                throw new ArgumentOutOfRangeException("inputType");
            }
        }
        private static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var inputType = GetType(textBox);
            if (IsValid(textBox.Text, inputType))
            {
                SetPreviousTextSelection(textBox, new TextSelection(textBox.Text, textBox.SelectionStart, textBox.SelectionLength));
            }
            else
            {
                var textSelection = GetPreviousTextSelection(textBox);
                if (textSelection == null)
                {
                    textBox.Text = "";
                }
                else
                {
                    textBox.Text = textSelection.Text;
                    textBox.SelectionStart = textSelection.SelectionStart;
                    textBox.SelectionLength = textSelection.SelectionLength;
                }
            }
        }
        private static void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            SetPreviousTextSelection(textBox, new TextSelection(textBox.Text, textBox.SelectionStart, textBox.SelectionLength));
        }
    }
