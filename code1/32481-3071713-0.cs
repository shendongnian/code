        private void cboAuthor_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboAuthor.Text.Length == 0)
            {
                // Next two lines simple load data from the database in the
                // into a collection (var gateway), base on first letter in
                // the combobox. This is specific to my app.
                var gateway = new AuthorTableGateway();
                gateway.LoadByFirstLetter(Char.ConvertFromUtf32(e.KeyValue)[0]);
                // Clear current source without calling Clear()
                for (int i = 0; i < authorsAutoComplete.Count; i++)
                    authorsAutoComplete.RemoveAt(0);
                // Rebuild with new data
                foreach (var author in gateway)
                    authorsAutoComplete.Add(author.AuthorName);
            }
        }
