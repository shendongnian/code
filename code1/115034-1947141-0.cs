    using System.Globalization;
    ....
            private string RemoveDuplicates(string text)
            {
                StringBuilder result = new StringBuilder();
                string previousTextElement = string.Empty;
                TextElementEnumerator textElementEnumerator = StringInfo.GetTextElementEnumerator(text);
                textElementEnumerator.Reset();
                while (textElementEnumerator.MoveNext())
                {
                    string textElement = (string)textElementEnumerator.Current;
                    if (string.Compare(previousTextElement, textElement, CultureInfo.InvariantCulture,
                        CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace |
                        CompareOptions.IgnoreWidth) != 0)
                    {
                        result.Append(textElement);
                        previousTextElement = textElement;
                    }
                }
                return result.ToString();
            }
