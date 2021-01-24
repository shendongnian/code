    public void UpdateObject(BookViewModel viewModel)
            {
                Book parsedBook = Mapper.Map<BookViewModel, Book>(viewModel);
                //Book viewModelBook = parseBook;
                var book = db.Books.Find(viewModel.BookId);
                book.BookId = parsedBook.BookId;
                book.BookName = parsedBook.BookName;
                book.Genre = parsedBook.Genre;
                book.Pages = parsedBook.Pages;
                book.Publisher = parsedBook.Publisher;
                UpdateAssociatedObject(book, parsedBook);
            }
         private void AddUpdatedAuthors(Book bookToUpdate, Book viewModelBook)
            {
                foreach (var authors in viewModelBook.BookAuthors)
                {
                    var searchBookAuthor = bookToUpdate.BookAuthors.Find(b => b.AuthorId == authors.AuthorId);
                    if (searchBookAuthor == null)
                    {
                        bookToUpdate.BookAuthors.Add(authors);
                    }
                }
            }
            private void RemoveUpdatedAuthors(Book bookToUpdate, Book viewModelBook)
            {
                int countOfAuthors = bookToUpdate.BookAuthors.Count;
                for (int i = 0; i < countOfAuthors; i++)
                {
                    BookAuthor searchBookAuthor = null;
                    foreach (var viewModelAuthors in viewModelBook.BookAuthors)
                    {
                        if (viewModelAuthors.AuthorId == bookToUpdate.BookAuthors[i].AuthorId)
                        {
                            searchBookAuthor = viewModelAuthors;
                        }
                    }
                    if (searchBookAuthor == null)
                    {
                        bookToUpdate.BookAuthors.Remove(bookToUpdate.BookAuthors[i]);
                        i--;
                        countOfAuthors--;
                    }
                }
            }
