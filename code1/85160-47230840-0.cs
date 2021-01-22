        private void TurnOnAutocomplete()
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            string[] arrayOfWowrds = new string[];
            try
            {
                //Read in data Autocomplete list to a string[]
                string[] arrayOfWowrds = new string[];
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            collection.AddRange(arrayOFWords);
            textBox.AutoCompleteCustomSource = collection;
        }
