    DescriptionText.TextChanged -= this.DescriptionText_TextChanged;
    var regExp = new Regex(@"^-*[0-9,\.]+$");
    foreach (Match match in regExp.Matches(rtb.Text))
        {
            var textRange = rtb.Selection;
            textRange.Select(match.Index, match.Length);
            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Red));
            //rtb.SelectionColor = Color.Red;
        }
    DescriptionText.TextChanged += this.DescriptionText_TextChanged;
