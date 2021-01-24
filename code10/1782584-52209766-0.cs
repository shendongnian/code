     public IActionResult Index(string searchString)
        {
            bool hasSearchResults = false;
            var model = _bookstoreData.GetAll();
            Func<Book, bool> searchFunc = (book) =>
            {
                string query = $"({searchString})";
                if (IsMatch(book.Title, query) || IsMatch(book.Author, query))
                    return true;
                return false;
            };
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(searchFunc).ToList();
                hasSearchResults = true;
            }
            return hasSearchResults ? View("SearchResult", model) : View(model);
        }
