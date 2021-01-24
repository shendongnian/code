    // Unfortunatelly, you won't be able to send the regex processing logic directly to the database.
    // You'll need to get the Content from the database and then iterate over the list and apply regex. 
    // This can be done by using .AsEnumerable(). It breaks the query into two part. 
    // First part is inside part( query before AsEnumerable()) is executed as Linq-to-SQL. 
    // Second part is outside part( query after AsEnumerable()) is executed as Linq-to-Objects.
    // First part is executed on database and all data brought in to the client side. 
    // Second part (here it is where, select) is performed on the client side. 
    // So in short AsEnumerable() operator move query processing to client side.
    
    var result = ( from a in db.tblmail_type.AsEnumerable()
                   where a.Id == Id
                   select new MailModel {
                            subject = a.Subject,
                            Content = Regex.Replace(a.Content, pattern, replace)
                  });
