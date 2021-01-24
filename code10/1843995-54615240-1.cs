    private List<Book> Books; // this will be accessible from anywhere in you form
    public BookStoreForm()
    {
          InitializeComponent();
          Books = new List<Book>();
          Book Book1 = new Book("Author", "ISBN", 5, "Title");
          Books.Add(Book1);
    
    }
    private void myEvnetHandler(object sender, EventArgs e)
    {
         Books.Add(new Book("Stephen R. Davis", "0764508148", 12.45m, "C# For Dummies"));
    }
