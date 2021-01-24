    private int currentWordIndex()
    {
        int currentWordIndex = 1;
        int charactersCounted = 1;
    
        if (richTextBox1.SelectionStart != 0)
        {
            foreach (Char character in richTextBox1.Text)
            {
                charactersCounted++;
    
                if (char.IsWhiteSpace(character))
                    currentWordIndex++;
    
                if (charactersCounted == richTextBox1.SelectionStart)
                    break;
            }
        }
    
        else
            currentWordIndex = 1;
    
        return currentWordIndex;
    }
