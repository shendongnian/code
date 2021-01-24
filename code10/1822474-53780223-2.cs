    public void RemoveBooks(int bookId) {
        // iterating from the end of the array
        // to prevent skipping over items
        for (int i = this.Books.Count - 1; i >= 0; i--) {
            if (this.Books[i].Id == bookId) {
                this.Books.RemoveAt(i);
            }
        }
    }
