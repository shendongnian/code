        // Edit the price of a book in the store
        public void EditPrice(int id, double newPrice)
        {
            var query = from book in context.Books
                        where book.Id == id
                        select book;
            Book BookToEdit = query.ToList()[0];
            BookToEdit.Price = newPrice;
            context.SaveChanges();
        }
