    dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
    dynamic books = xl.Workbooks;
    dynamic book = books.Add();
    Console.WriteLine(books.Count);		//Writes 1
    foreach (dynamic b in books)		
    {
	Console.WriteLine(b.Name);		//Writes "Book1"
    }
