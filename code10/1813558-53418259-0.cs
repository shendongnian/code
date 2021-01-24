    private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                var textBox = (TextBox)sender;
                var currentText = textBox.Text;
    
                if (currentText.Length + 1 < 3) return;
    
                if ((textBox.GetDigitsCount()) % 3 == 0 && currentText.Length != 2)
                {
                    textBox.Text = !textBox.HasAnyCommas() 
                        ? currentText.Insert(1, ",") 
                        : textBox.Text.Insert(textBox.Text.Length - 2, ",");
                }
    
                textBox.SelectionStart = textBox.Text.Length;
            }
    public static class Ex
        {
            public static int GetDigitsCount(this TextBox @this) => @this.Text.Count(char.IsDigit);
            public static bool HasAnyCommas(this TextBox @this) => @this.Text.Any(x => x == ',');
        }
