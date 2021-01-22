    Book temp;
    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        temp = (Book) bf.Deserialize(fs);
    
    MemberInfo[] members = FormatterServices.GetSerializableMembers(typeof (Book));
    FormatterServices.PopulateObjectMembers(book, members, FormatterServices.GetObjectData(temp, members));
    
    // Object state is back
    Console.WriteLine("{0}, {1}", book.Title, book.Author);
