                if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }
            int cursorPos = textBox1.SelectionStart;
            int firstPos = 0;
            int lastPost = 0;
            // If the current cursor is at the end of the string, try to go backwards
            string currentChar = cursorPos == textBox1.Text.Length ? textBox1.Text.Substring(cursorPos - 1, 1) : textBox1.Text.Substring(cursorPos, 1);
            if (currentChar == " ") 
            {
                cursorPos--;
            }
            // Iterate to the first position where a space is
            for (int i = cursorPos; i > 0; i--)
            {
                // Get the current character
                currentChar = i == textBox1.Text.Length ? textBox1.Text.Substring(i - 1, 1) : textBox1.Text.Substring(i, 1);
                if (currentChar == " ")
                {
                    firstPos = i+1;
                    break;
                }
            }
            for (int i = cursorPos; i <= textBox1.Text.Length; i++)
            {
                if (i == textBox1.Text.Length)
                {
                    lastPost = i;
                }
                else
                {
                    // Get the current character
                    currentChar = textBox1.Text.Substring(i, 1);
                    if (currentChar == " ")
                    {
                        lastPost = i;
                        break;
                    }
                }
            }
            textBox1.SelectionStart = firstPos;
            textBox1.SelectionLength = lastPost - firstPos;
            textBox1.Focus();
