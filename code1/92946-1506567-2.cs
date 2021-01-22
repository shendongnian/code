    private void FindButton_Click(object sender, EventArgs e)
        {
            findOptions = default(RichTextBoxFinds);
            resultsListBox.Items.Clear();
            if (MatchCaseCheckBox.Checked)
            {
                findOptions = findOptions | RichTextBoxFinds.MatchCase;
            }
            if (MatchEntireWordCheckBox.Checked)
            {
                findOptions = findOptions | RichTextBoxFinds.WholeWord;
            }
            int[] foundLocations = FindSearchResults(TextToSearchTextBox.Text.Trim());
            string[] words = null;
            if (foundLocations.Length > 0)
            {
                words = GetWords(foundLocations);
            }
            foreach (string word in words)
            {
                resultsListBox.Items.Add(word);
            }
        }
        private string[] GetWords(int[] foundLocations)
        {
            string textChunk = string.Empty;
            int chunkSize = 64;
            int textLength = MyRichTextBox.TextLength;
            int startIndex = 0;
            int endIndex = 0;
            List<string> words = new List<string>();
            int lastSpaceIndex = -1;
            int firstSpaceIndex = -1;
            foreach (int location in foundLocations)
            {
                textChunk = string.Empty;
                startIndex = location;
                endIndex = location;
                firstSpaceIndex = -1;
                lastSpaceIndex = -1;
                //get the start index.
                while (startIndex >= 0)
                {
                    if (startIndex - chunkSize >= 0)
                    {
                        startIndex -= chunkSize;
                    }
                    else
                    {
                        startIndex -= Math.Abs(startIndex);
                    }
                    textChunk += MyRichTextBox.Text.Substring(startIndex, location - startIndex);
                    firstSpaceIndex = textChunk.LastIndexOf(' ');
                    if (firstSpaceIndex > -1)
                    {
                        firstSpaceIndex = location - (textChunk.Length - firstSpaceIndex);
                        break;
                    }
                }
                textChunk = string.Empty;
                startIndex = location;
                if (firstSpaceIndex == -1)
                {
                    firstSpaceIndex = 0;
                }
                while (textChunk.Length <= textLength)
                {
                    if (chunkSize + location < textLength)
                    {
                        endIndex = chunkSize;
                    }
                    else
                    {
                        endIndex = (textLength - startIndex);
                    }
                    textChunk += MyRichTextBox.Text.Substring(firstSpaceIndex + 1,
                        endIndex);
                    lastSpaceIndex = textChunk.IndexOf(' ');
                    if (lastSpaceIndex > -1)
                    {
                        words.Add(textChunk.Substring(0, lastSpaceIndex));
                        break;
                    }
                }
            }
            return words.ToArray();
        }
        private int[] FindSearchResults(string textToSearchFor)
        {
            
            int textLength = MyRichTextBox.TextLength;
            int chunkSize = 128;
            int startIndex = 0;
            int endIndex = 0;
            int foundIndex = -1;
            List<int> foundLocations = new List<int>();
            while (startIndex < textLength)
            {
                if ((chunkSize + startIndex) < textLength)
                {
                    endIndex += chunkSize;
                }
                else
                {
                    endIndex += textLength - endIndex;
                }
                foundIndex = MyRichTextBox.Find(textToSearchFor, startIndex, endIndex, findOptions);
                if (foundIndex > -1)
                {
                    foundLocations.Add(foundIndex);
                }
                startIndex += chunkSize;
            }
            return foundLocations.ToArray();
        }
