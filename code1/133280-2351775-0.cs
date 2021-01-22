    class AutoSuggestControl : TextBox
    {
        List<string> Suggestions;
        int PreviousLength; 
        public AutoSuggestControl() : base()
        {
            Suggestions = new List<string>();
            // We keep track of the previous length of the string
            // If the user tries to delete characters we do not interfere
            PreviousLength = 0; 
            // Very basic list, too slow to be suitable for systems with many entries
            foreach(var e in yourListbox.Items)
            {
                //add your listbox items to the textbox
            }
            Suggestions.Sort();
        }
        /// <summary>
        /// Search through the collection of suggestions for a match
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private string FindSuggestion(string Input)
        {
            if (Input != "")
            foreach (string Suggestion in Suggestions)
            {
                if (Suggestion.StartsWith(Input))
                    return Suggestion;
            }
            return null;
        }
        /// <summary>
        /// We only interfere after receiving the OnTextChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            // We don't do anything if the user is trying to shorten the sentence
            int CursorPosition = SelectionStart;
            if (Text.Length > PreviousLength && CursorPosition >= 0)
            {
                string Suggestion = FindSuggestion(Text.Substring(0, CursorPosition));
                if (Suggestion != null)
                {
                    // Set the contents of the textbox to the suggestion
                    Text = Suggestion;
                    // Setting text puts the cursor at the beginning of the textbox, so we need to reposition it
                    Select(CursorPosition, 0);
                }
            }
            PreviousLength = Text.Length;
        }
    }
