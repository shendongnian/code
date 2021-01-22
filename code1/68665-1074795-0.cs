    string myList = Request.Form["myList"];
    if(string.isNullOrEmpty(myList))
    {
        Response.Write("Nothing selected.");
        return;
    }
    foreach (string Item in Request.Form["mylist"].split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
    {
      Response.Write(Request.Form["mylist"][Item] + "<hr>");
    }
