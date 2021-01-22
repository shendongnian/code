      XDocument objBooksXML = XDocument.Load(Server.MapPath("books.xml"));
        var objBooks = from book in
                       objBooksXML.Descendants("Book")
                       select new { 
                                    Title = book.Element("Title").Value, 
                                    Pages = book.Element("Pages").Value 
                                  };
        Response.Write(String.Format("Total {0} books.", objBooks.Count()));
        gvBooks.DataSource = objBooks;
        gvBooks.DataBind();
