        private static List<Book> RemoveDuplicateBooks(List<Book> library)
        {
            var distinctLib = from c in library
                            group c by new
                            { 
                                c.book_Name,
                                c.book_Dictionary
                            } into temp
                            select new Book()
                            {
                                book_Name = temp.First().book_Name,
                                book_Dictionary = temp.First().book_Dictionary
                            };
            return distinctLib.ToList();
        }
