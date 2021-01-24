    // in Inventory class having List<Book> Books,
    // assuming Book has a public int Id property
    public void RemoveBook(int bookId) {
        for (int i = 0; i < this.Books.Count; i++) {
            if (this.Books[i].Id == bookId) {
                this.Books.RemoveAt(i);
            }
        }
    }
