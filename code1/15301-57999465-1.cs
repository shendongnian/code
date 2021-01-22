        public partial class Library {
            List<Book> Books { get; set; }
            partial void InitializePartial() {
                Books = new List<Book>();
            }
        }
    
        public class Book {
            public string Title { get; set; }
        }
