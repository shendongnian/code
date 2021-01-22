    int cursorPos = textBox1.SelectionStart;
            int firstPos = 0;
            int lastPost = 0;
            // Iterate to the first position where a space is
            for (int i = cursorPos; i > 0; i--)
            {
                // Get the current character
                string currentChar = textBox1.Text.Substring(i, 1);
                if (currentChar == " ")
                {
                    firstPos = i;
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
                    string currentChar = textBox1.Text.Substring(i, 1);
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
