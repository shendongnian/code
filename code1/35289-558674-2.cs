    public IAdapter<Book> TestBookAdapter : IAdapter<Book>
    {
       private List<Book> Books = new List<Book>();
       public TestBookAdapter()
       {
          Books.Add(new Book { ID=1, Title="Test data", AvailableForCheckout=false };
          Books.Add(new Book { ID=2, Title="Test data", AvailableForCheckout=true };
       }
       Book Retrieve(int id)
       {
          return Books.Where(x => x.ID == id);
       }
    }
