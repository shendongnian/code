    public class DataTableBookAdapter : IAdapter<Book>
    {
       public DataTable Table { get; set; }
       private List<Book> Books = new List<Book>();
       Book Retrieve(int id)
       {
          Book b = Books.Where(x => x.ID = id).FirstOrDefault();
          if (b != null)
          {
             return b;
          }
          BookRow r = Table.Find(id);
          b = new Book();
          b.ID = r.Field<int>("ID");
          b.Title = r.Field<string>("Title");
          b.AvailableForCheckout = r.Field<bool>("AvailableForCheckout");
          return b;
       }
    }
