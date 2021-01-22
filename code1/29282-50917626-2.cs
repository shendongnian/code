    public sealed class PositiveNumberTextBox : RegexedTextBox<ulong> {
        public PositiveNumberTextBox() : base(@"^\d*$") { }
    }
    
    public sealed class PositiveFloatingPointNumberTextBox : RegexedTextBox<double> {
        public PositiveFloatingPointNumberTextBox()
            : base(@"^(\d+\" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + @")?\d*$") { }
    }
