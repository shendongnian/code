    public class Book
    {
      public int Id { get; set; }
      public Decimal Price { get; set; }
      public DateTime EndDate{ get; set; }
      public string tag1{ get; set; }
      public string  tag1{ get; set; }
    }
    //....
    
    XDocument xmlDoc = XDocument.Load("Books.xml");
    List<Book> BookList1=
      (from Book in xmlDoc.Descendants("Book")
       select new Tutorial
       {
         Id = tutorial.Element("Id").Value,
         Price = tutorial.Element("Price").Value,
         EndDate = DateTime.Parse(tutorial.Element("EndDate").Value),
         tag1= tutorial.Element("tag1").Value,
         tag2= tutorial.Element("tag2").Value
       }).ToList<Tutorial>();
    //....
    var BookGroups = from g in  BookList1 group g by Id into g
    select new{Key=g.Key,Books=g};
