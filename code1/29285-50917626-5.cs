    public sealed class PositiveNumberTextBox : RegexedTextBox {
        public PositiveNumberTextBox() : base(@"^\d*$") { }
    }
    
    public sealed class PositiveFloatingPointNumberTextBox : RegexedTextBox {
        public PositiveFloatingPointNumberTextBox()
            : base(@"^(\d+\" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + @")?\d*$") { }
    }
